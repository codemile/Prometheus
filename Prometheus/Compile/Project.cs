using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Logging;
using Prometheus.Compile.Optomizer;
using Prometheus.Compile.Packaging;
using Prometheus.Exceptions.Compiler;
using Prometheus.Nodes;
using Prometheus.Packages;
using Prometheus.Sources;

namespace Prometheus.Compile
{
    /// <summary>
    /// Responsible for compiling packages and assembling them together.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Logging
        /// </summary>
        private static readonly Logger _logger = Logger.Create(typeof (Project));

        /// <summary>
        /// The package loaders.
        /// </summary>
        private readonly MultiLoader _loader;

        /// <summary>
        /// Constructor
        /// </summary>
        public Project()
        {
            _loader = new MultiLoader();
        }

        /// <summary>
        /// Adds a directory as a library. With the directory name
        /// the name of the library.
        /// </summary>
        public void AddDirectory(string pPath)
        {
            Add(new DirectoryLoader(pPath));
        }

        /// <summary>
        /// Add a package loader
        /// </summary>
        public void Add(iPackageLoader pLoader)
        {
            _loader.Add(pLoader);
        }

        /// <summary>
        /// Builds the current project.
        /// </summary>
        /// <param name="pClassName">Name of the file to build.</param>
        public void Build(ClassNameType pClassName)
        {
            Builder make = new Builder(_loader);
            make.BeforeOptimizer += PrintCompiled;
            make.AfterOptimizer += PrintCompiled;
            Package package = make.Start(pClassName);
        }

        /// <summary>
        /// Prints the node tree.
        /// </summary>
        private static void PrintCompiled(Node pNode)
        {
            _logger.Debug("");
            PrintCode(pNode);
            _logger.Debug("");
        }

        /// <summary>
        /// Walks the tree of nodes displaying details about each node.
        /// </summary>
        private static void PrintCode(Node pNode, int pIndent = 0)
        {
            _logger.Debug("{0} {1} {2}", " ".PadLeft(pIndent * 2), pNode.Type, string.Join(" ", pNode.Data));

            foreach (Node child in pNode.Children)
            {
                PrintCode(child, pIndent + 1);
            }
        }
    }
}