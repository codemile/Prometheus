using System;
using System.Collections.Generic;
using System.Linq;
using Prometheus.Nodes.Types;
using Prometheus.Objects;

namespace Prometheus.Storage
{
    /// <summary>
    /// Holds all the declarations for single namespace.
    /// </summary>
    public class NameSpace : IDisposable
    {
        /// <summary>
        /// The name of the root namespace for all namespaces
        /// </summary>
        public static readonly QualifiedType Empty = new QualifiedType("empty");

        /// <summary>
        /// The name of the root namespace for all namespaces
        /// </summary>
        public static readonly QualifiedType Global = new QualifiedType("global");

        /// <summary>
        /// The name of this namespace.
        /// </summary>
        public readonly QualifiedType Name;

        /// <summary>
        /// The child namespaces of this space.
        /// </summary>
        private readonly Dictionary<string, NameSpace> _childSpaces;

        /// <summary>
        /// All the declarations in this package.
        /// </summary>
        private readonly Dictionary<string, Declaration> _declarations;

        /// <summary>
        /// Checks if this namespace contains anything
        /// </summary>
        public bool isEmpty
        {
            get { return _childSpaces.Count == 0 && _declarations.Count == 0; }
        }

        /// <summary>
        /// Walks the children until it finds the correct namespace to store this declaration.
        /// </summary>
        /// <param name="pDecl">The declaration to add</param>
        /// <param name="pParts">The list of namespace names</param>
        /// <param name="pIndex">Current index into parts</param>
        /// <returns>True if successful, or False if not added.</returns>
        private bool Add(IList<string> pParts, Declaration pDecl, int pIndex)
        {
            if (pIndex != pParts.Count)
            {
                string package = pParts[pIndex];
                return _childSpaces.ContainsKey(package) && _childSpaces[package].Add(pParts, pDecl, pIndex + 1);
            }

            string name = pDecl.Identifier.Name;
            if (_declarations.ContainsKey(name))
            {
                return false;
            }

            _declarations.Add(name, pDecl);
            return true;
        }

        /// <summary>
        /// Walks the children creating namespaces.
        /// </summary>
        /// <param name="pType">The list of namespace names</param>
        /// <param name="pIndex">Current index into parts</param>
        /// <returns>True if successful, or False if not added.</returns>
        private bool Declare(QualifiedType pType, int pIndex)
        {
            string name = pType.Parts[pIndex];

            bool added = false;
            if (!_childSpaces.ContainsKey(name))
            {
                _childSpaces.Add(name, new NameSpace(new QualifiedType(pType.Parts.Take(pIndex + 1).ToArray())));
                added = true;
            }

            return pIndex == pType.Parts.Length - 1 ? added : _childSpaces[name].Declare(pType, pIndex + 1);
        }

        /// <summary>
        /// Returns the definition of an object by searching this namespace and it's children.
        /// </summary>
        private Declaration Get(string pName)
        {
            return _declarations.ContainsKey(pName) ? _declarations[pName] : null;
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
        /// Constructor
        /// </summary>
        public NameSpace(QualifiedType pName)
        {
            Name = pName;

            _declarations = new Dictionary<string, Declaration>();
            _childSpaces = new Dictionary<string, NameSpace>();
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
        /// Creates the root namespace used by the parser.
        /// </summary>
        /// <returns></returns>
        public static NameSpace Create()
        {
            NameSpace root = new NameSpace(new QualifiedType(""));
            root.Declare(Global);
            return root;
        }

        /// <summary>
        /// Adds an object declaration to this namespace, or a children space
        /// that matches the identifier for the declaration.
        /// </summary>
        /// <param name="pDecl">The declaration to add</param>
        /// <returns>True if successful, or False if not added.</returns>
        public bool Add(Declaration pDecl)
        {
            return Add(pDecl.NameSpace.Parts, pDecl, 0);
        }

        /// <summary>
        /// Access a child package.
        /// </summary>
        /// <param name="pPackage">The name of the child</param>
        /// <returns>The child package</returns>
        public NameSpace Child(string pPackage)
        {
            return _childSpaces.ContainsKey(pPackage) ? _childSpaces[pPackage] : null;
        }

        /// <summary>
        /// Declares a namespaces
        /// </summary>
        /// <param name="pType">The namespace without members</param>
        /// <returns>True if successful, False if already exists.</returns>
        public bool Declare(QualifiedType pType)
        {
            return Declare(pType, 0);
        }

        /// <summary>
        /// Gets the declaration of an object.
        /// </summary>
        /// <param name="pQualifiedType">The identifier</param>
        /// <returns>The declaration or null.</returns>
        public Declaration Get(QualifiedType pQualifiedType)
        {
            return Get(pQualifiedType.Parts, 0);
        }

        /// <summary>
        /// Prints a list of object declarations grouped by namespace.
        /// </summary>
        /// <param name="pLines">The output string</param>
        /// <param name="pIndent">The current indent</param>
        public void Print(ref List<string> pLines, int pIndent = 0)
        {
            if (!string.IsNullOrEmpty(Name.FullName))
            {
                pLines.Add(string.Format("{0}:",Name));
            }

            pLines.AddRange(
                _declarations
                .Values
                .OrderBy(pValue=>pValue)
                .Select(pDecl=>string.Format("{0}:{1}", Name, pDecl.Identifier.Name)));

            foreach (NameSpace child in _childSpaces.Values.OrderBy(pValue=>pValue.Name.FullName))
            {
                child.Print(ref pLines, pIndent + 1);
            }
        }

        /// <summary>
        /// Checks if a declaration exists in the current package.
        /// </summary>
        /// <param name="pName">The declaration</param>
        /// <returns>True if exists</returns>
        public bool isDeclaration(string pName)
        {
            return _declarations.ContainsKey(pName);
        }

        /// <summary>
        /// Checks if a package exists.
        /// </summary>
        /// <param name="pPackage">The package name</param>
        /// <returns>True if it exists</returns>
        public bool isPackage(string pPackage)
        {
            return _childSpaces.ContainsKey(pPackage);
        }
    }
}