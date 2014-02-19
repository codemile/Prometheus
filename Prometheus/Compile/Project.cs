using System.Collections.Generic;
using System.IO;
using Logging;
using Prometheus.Compile.Packaging;
using Prometheus.Exceptions.Compiler;
using Prometheus.Nodes;

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
        /// A list of directories to compile.
        /// </summary>
        private readonly List<string> _directories;

        /// <summary>
        /// Logs what file is being built.
        /// </summary>
        private static bool LogFileName(string pFileName)
        {
            _logger.Fine("Compile: {0}", pFileName);
            return true;
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

        /// <summary>
        /// Prints the node tree.
        /// </summary>
        private static bool PrintCompiled(Node pNode)
        {
            _logger.Debug("");
            PrintCode(pNode);
            _logger.Debug("");
            return true;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Project()
        {
            _directories = new List<string>();
        }

        /// <summary>
        /// Recursively adds files from a directory and all sub-directories.
        /// </summary>
        public void AddDirectory(string pDirectory)
        {
            if (!Directory.Exists(pDirectory))
            {
                throw new PackageErrorException(string.Format("Directory does not exist: {0}", pDirectory));
            }
            _directories.Add(pDirectory);
        }

        /// <summary>
        /// Builds the current project.
        /// </summary>
        public void Build()
        {
            Builder make = new Builder();
            make.OnBeforeOptimizer += PrintCompiled;
            make.OnAfterOptimizer += PrintCompiled;
            make.OnDirectory += LogFileName;
            make.OnFile += LogFileName;
            Compiled compiled = make.Build(_directories);

            _logger.Fine("********* DONE *********");
            PrintCompiled(compiled.Root);
        }
    }
}