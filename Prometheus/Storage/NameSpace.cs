using System;
using System.Collections.Generic;
using Logging;
using Prometheus.Nodes.Types;

namespace Prometheus.Objects
{
    /// <summary>
    /// Holds all the declarations for single namespace.
    /// </summary>
    public class NameSpace : IDisposable
    {
        /// <summary>
        /// Logging
        /// </summary>
        private static readonly Logger _logger = Logger.Create(typeof(NameSpace));

        /// <summary>
        /// The child namespaces of this space.
        /// </summary>
        private readonly Dictionary<string, NameSpace> _childSpaces;

        /// <summary>
        /// All the declarations in this package.
        /// </summary>
        private readonly Dictionary<string, Declaration> _declarations;

        /// <summary>
        /// Returns the definition of an object by searching this namespace and it's children.
        /// </summary>
        private Declaration Get(string pName)
        {
            return _declarations.ContainsKey(pName) ? _declarations[pName] : null;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public NameSpace()
        {
            _declarations = new Dictionary<string, Declaration>();
            _childSpaces = new Dictionary<string, NameSpace>();
        }

        /// <summary>
        /// Adds an object declaration to this namespace, or a children space
        /// that matches the identifier for the declaration.
        /// </summary>
        /// <param name="pDecl">The declaration to add</param>
        /// <returns>True if successful, or False if not added.</returns>
        public bool Add(Declaration pDecl)
        {
            string[] parts = pDecl.Name.Name.Split(new[] {'.'});
            return Add(pDecl, parts, 0);
        }

        /// <summary>
        /// Walks the children until it finds the correct namespace to store this declaration.
        /// </summary>
        /// <param name="pDecl">The declaration to add</param>
        /// <param name="pParts">The list of namespace names</param>
        /// <param name="pIndex">Current index into parts</param>
        /// <returns>True if successful, or False if not added.</returns>
        private bool Add(Declaration pDecl, IList<string> pParts, int pIndex)
        {
            string name = pParts[pIndex];

            if (pIndex != pParts.Count - 1)
            {
                return _childSpaces.ContainsKey(name) && _childSpaces[name].Add(pDecl, pParts, pIndex + 1);
            }

            if (_declarations.ContainsKey(name))
            {
                return false;
            }

            _declarations.Add(name, pDecl);
            return true;
        }

        /// <summary>
        /// Gets the declaration of an object.
        /// </summary>
        /// <param name="pIdentifier">The identifier</param>
        /// <returns>The declaration or null.</returns>
        public Declaration Get(Identifier pIdentifier)
        {
            string[] parts = pIdentifier.Name.Split(new[] { '.' });
            return Get(parts, 0);
        }

        /// <summary>
        /// Finds a declaration in this namespace or it's children.
        /// </summary>
        private Declaration Get(string[] pParts, int pIndex)
        {
            if (pIndex >= pParts.Length)
            {
                return null;
            }
            string name = pParts[pIndex];
            return _childSpaces.ContainsKey(name) ? _childSpaces[name].Get(pParts, pIndex + 1) : Get(name);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            foreach (NameSpace child in _childSpaces.Values)
            {
                child.Dispose();
            }
            _childSpaces.Clear();
            _declarations.Clear();
        }

        /// <summary>
        /// Prints a list of object declarations grouped by namespace.
        /// </summary>
        /// <param name="pIndent">The current indent</param>
        public void Print(int pIndent = 0)
        {
            string indent = string.Format("{0}> ", " ".PadLeft(pIndent));
            foreach (Declaration decl in _declarations.Values)
            {
                _logger.Fine("{0}{1}", indent, decl.ToString());
            }
            foreach (NameSpace child in _childSpaces.Values)
            {
                child.Print(pIndent+1);
            }
        }
    }
}