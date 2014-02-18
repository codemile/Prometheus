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
        /// The compiler
        /// </summary>
        private readonly Compiler _compiler;

        /// <summary>
        /// The package loaders.
        /// </summary>
        private readonly List<iPackageLoader> _loaders;

        /// <summary>
        /// Constructor
        /// </summary>
        public Project()
        {
            _compiler = new Compiler();
            _loaders = new List<iPackageLoader>();
        }

        /// <summary>
        /// Adds a folder to the build path.
        /// </summary>
        public void Add(string pPath)
        {
            Add(new DirectoryLoader(pPath));
        }

        /// <summary>
        /// Add a package loader
        /// </summary>
        public void Add(iPackageLoader pLoader)
        {
            _loaders.Add(pLoader);
        }

        /// <summary>
        /// Builds the current project.
        /// </summary>
        /// <param name="pFileName">Name of the file to build.</param>
        public void Build(string pFileName)
        {
            string fullPath = Path.GetFullPath(pFileName);
            string directory = Path.GetPathRoot(fullPath);

            // start by compiling the first file
            string contents = Reader.Open(pFileName);
            Compile(pFileName, contents);
        }

        private void Compile(string pFileName, string pSourceCode)
        {
            Node root = _compiler.Compile(pFileName, pSourceCode);
            root = Optimize(root);
            //CodeFile code = new CodeFile(root);
        }

        /// <summary>
        /// Optimizes the compiled node tree to a structure the parser can
        /// read and make assumptions about.
        /// </summary>
        private static Node Optimize(Node pRoot)
        {
#if DEBUG
            TraceCode("Before Optimizer", pRoot);
#endif
            Optimizer optimizer = new Optimizer();
            pRoot = optimizer.Optimize(pRoot);
#if DEBUG
            TraceCode("After Optimizer", pRoot);
#endif
            return pRoot;
        }

#if DEBUG
        /// <summary>
        /// Dumps a trace of the code tree to the console.
        /// </summary>
        private static void TraceCode(string pMessage, Node pRoot)
        {
            _logger.Debug(pMessage);
            PrintCode(pRoot);
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
#endif

        /// <summary>
        /// Compiles a source code file and it's dependent packages. The package is
        /// loaded using the package loaders.
        /// </summary>
        /// <param name="pPackageName">The name of the source code file.</param>
        /// <returns>The compiled program</returns>
        public CodeFile Compile(string pPackageName)
        {
/*
            IList<iPackageReader> readers = _loaders.Load(pPackageName);
            if (readers == null || !readers.Any())
            {
                throw new PackageNotFoundException(string.Format("Package was not found: {0}", pPackageName));
            }
            if (readers.Count != 1)
            {
                throw new PackageNotFoundException(string.Format("More then one package found for main package: {0}",
                    pPackageName));
            }

            List<string> packages = new List<string>();
            do
            {
                CodeFile codeFile = Compile(readers[0]);
                packages.AddRange(from import in codeFile.Imports where !packages.Contains(import) select import);
            } while (packages.Count != 0);
*/
            return null;
        }
    }
}