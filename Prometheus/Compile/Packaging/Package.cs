using System.Collections.Generic;
using Prometheus.Nodes;

namespace Prometheus.Compile.Packaging
{
    /// <summary>
    /// Represents a compiled package.
    /// </summary>
    public class Package
    {
        /// <summary>
        /// The child of this package.
        /// </summary>
        public readonly Dictionary<string, Package> Children;

        /// <summary>
        /// The code from each file.
        /// </summary>
        public readonly List<Node> Codes;

        /// <summary>
        /// The objects declared in the package.
        /// </summary>
        public readonly List<Node> Declarations;

        /// <summary>
        /// The name of this package.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Walk the tree of packages to find the last one.
        /// </summary>
        private Package Get(IList<string> pName, int pIndex)
        {
            if (pName[pIndex] == Name && pIndex == pName.Count - 1)
            {
                return this;
            }

            string child = pName[pIndex + 1];

            if (!Children.ContainsKey(child))
            {
                Children.Add(child, new Package(child));
            }

            return Children[child];
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Package(string pName)
        {
            Name = pName;
            Children = new Dictionary<string, Package>();
            Declarations = new List<Node>();
            Codes = new List<Node>();
        }

        /// <summary>
        /// Adds the code file to the package it belongs to.
        /// </summary>
        public void Add(CodeFile pCode)
        {
            Package pack = Get(pCode.Package);
            pack.Declarations.AddRange(pCode.Declarations);
            pack.Codes.Add(pCode.Code);
        }

        /// <summary>
        /// Retrieves a package
        /// </summary>
        /// <param name="pName">The name of the package.</param>
        /// <returns>The package object</returns>
        public Package Get(ClassNameType pName)
        {
            return Get(pName.Members, 0);
        }
    }
}