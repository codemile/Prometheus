using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Logging;
using Prometheus.Compile.Optomizer;
using Prometheus.Compile.Packaging;
using Prometheus.Exceptions.Compiler;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Packages;

namespace Prometheus.Compile
{
    /// <summary>
    /// </summary>
    public class Builder
    {
        /// <summary>
        /// Logging
        /// </summary>
        private static readonly Logger _logger = Logger.Create(typeof (Builder));

        /// <summary>
        /// Handles compiling code.
        /// </summary>
        private readonly Compiler _compiler;

        /// <summary>
        /// A list of files to include in the file.
        /// </summary>
        private readonly List<string> _includePath;

        /// <summary>
        /// Logs what file is being built.
        /// </summary>
        private static void LogFileName(string pFileName)
        {
            _logger.Fine("Compile: {0}", pFileName);
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
        private static void PrintCompiled(Node pNode)
        {
            _logger.Debug("");
            PrintCode(pNode);
            _logger.Debug("");
        }

        /// <summary>
        /// Compiles a file.
        /// </summary>
        private Node BuildFile(string pFileName)
        {
            LogFileName(pFileName);

            using (StreamReader reader = new StreamReader(pFileName))
            {
                string sourceCode = reader.ReadToEnd();
                Node root = _compiler.Compile(pFileName, sourceCode);
                return Optimize(root);
            }
        }

        private void BuildImports(Compiled pCode, string pRelative, string pFileName)
        {
            string file = FindFile(pRelative, pFileName);
            if (file == null)
            {
                throw new PackageErrorException(string.Format("File not found: {0}", pFileName));
            }

            // import only once
            if (pCode.Files.Contains(file))
            {
                return;
            }

            Node root = BuildFile(file);
            pCode.Files.Add(file);

            // place imported code before main file
            foreach (string import in from node in root.Children
                                      where node.Type == GrammarSymbol.ImportDecl
                                      select node.FirstData().Cast<StringType>().Value)
            {
                BuildImports(pCode, Path.GetDirectoryName(file), import);
            }

            pCode.Imported.Add(root);
        }

        /// <summary>
        /// Finds an imported file via the include paths.
        /// </summary>
        private string FindFile(string pRelative, string pFileName)
        {
            string file = pFileName.Replace("/", Path.DirectorySeparatorChar.ToString(CultureInfo.InvariantCulture));
            file = Reader.getFileNameWithExtension(file, "fire");

            // absolute path check
            if (File.Exists(file))
            {
                return file;
            }

            // relative path check
            if (pRelative != null)
            {
                string relative = Path.GetFullPath(pRelative + Path.DirectorySeparatorChar + file);
                if (File.Exists(relative))
                {
                    return relative;
                }
            }

            // include path check
            foreach (string dir in _includePath)
            {
                string path = dir + Path.DirectorySeparatorChar + file;
                if (File.Exists(path))
                {
                    return path;
                }
            }

            return null;
        }

        /// <summary>
        /// Optimizes the compiled node tree to a structure the parser can
        /// read and make assumptions about.
        /// </summary>
        private Node Optimize(Node pRoot)
        {
            PrintCompiled(pRoot);
            Optimizer optimizer = new Optimizer();
            pRoot = optimizer.Optimize(pRoot);
            PrintCompiled(pRoot);
            return pRoot;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Builder()
        {
            _includePath = new List<string>();
            _compiler = new Compiler();
        }

        /// <summary>
        /// Adds a directory to the include path.
        /// </summary>
        public void AddDirectory(string pIncludePath)
        {
            if (pIncludePath.EndsWith(Path.DirectorySeparatorChar.ToString(CultureInfo.InvariantCulture)))
            {
                pIncludePath = pIncludePath.Substring(0, pIncludePath.Length - 1);
            }
            if (!Directory.Exists(pIncludePath))
            {
                throw new PackageErrorException(string.Format("Directory not found: {0}", pIncludePath));
            }
            _includePath.Add(pIncludePath);
        }

        /// <summary>
        /// Compiles all the files in the current build.
        /// </summary>
        public Compiled Build(string pFileName)
        {
            Compiled compiled = new Compiled();
            string relative = Path.GetDirectoryName(pFileName);
            BuildImports(compiled, relative, pFileName);
            return compiled;
        }
    }
}