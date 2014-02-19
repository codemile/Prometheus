using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Prometheus.Compile.Optomizer;
using Prometheus.Compile.Packaging;
using Prometheus.Nodes;

namespace Prometheus.Compile
{
    /// <summary>
    /// </summary>
    public class Builder
    {
        /// <summary>
        /// Callback during the build process.
        /// </summary>
        public delegate bool BuildEvent<in T>(T pArgument) where T : class;

        /// <summary>
        /// Handles compiling code.
        /// </summary>
        private readonly Compiler _compiler;

        /// <summary>
        /// The compiled code.
        /// </summary>
        private Compiled _compiled;

        /// <summary>
        /// A list of files to include in the file.
        /// </summary>
        private List<string> _directories;

        /// <summary>
        /// Handles the firing of an event.
        /// </summary>
        private static bool Fire<T>(BuildEvent<T> pEvent, T pArg) where T : class
        {
            return pEvent == null || pEvent(pArg);
        }

        /// <summary>
        /// Compiles all the files in a directory.
        /// </summary>
        private void BuildDirectory(string pDirectory)
        {
            if (!Fire(OnDirectory, pDirectory))
            {
                return;
            }

            string[] folders = pDirectory.Split(Path.DirectorySeparatorChar);
            string name = folders[folders.Length - 1].ToLower();
            string baseDir = pDirectory.Substring(0,pDirectory.Length-name.Length);
            ClassNameType className = new ClassNameType(name);

            Directory.GetDirectories(pDirectory).ToList().ForEach(pDir=>IncludeSubdirectory(baseDir,pDir));
            Directory.GetFiles(pDirectory, "*.fire").ToList().ForEach(pFile=>BuildFile(className,pFile));
        }

        /// <summary>
        /// Compiles all the subdirectories as sub-namespaces
        /// </summary>
        private void IncludeSubdirectory(string pBaseDirectory, string pDirectory)
        {
            string packageName = pDirectory.Substring(pBaseDirectory.Length).ToLower();
            packageName = packageName.Replace(Path.DirectorySeparatorChar.ToString(CultureInfo.InvariantCulture), ".");
            ClassNameType className = new ClassNameType(packageName);

            Directory.GetDirectories(pDirectory).ToList().ForEach(pDir=>IncludeSubdirectory(pBaseDirectory,pDir));
            Directory.GetFiles(pDirectory, "*.fire").ToList().ForEach(pFile=>BuildFile(className,pFile));
        }

        /// <summary>
        /// Compiles a file.
        /// </summary>
        private void BuildFile(ClassNameType pClassName, string pFileName)
        {
            if (!Fire(OnFile, pFileName))
            {
                return;
            }
            using (StreamReader reader = new StreamReader(pFileName))
            {
                string sourceCode = reader.ReadToEnd();

                Node root = _compiler.Compile(pFileName, sourceCode);
                root = Optimize(root);
                _compiled.Add(pClassName, root);
            }
        }

        /// <summary>
        /// Optimizes the compiled node tree to a structure the parser can
        /// read and make assumptions about.
        /// </summary>
        private Node Optimize(Node pRoot)
        {
            Fire(OnBeforeOptimizer, pRoot);
            Optimizer optimizer = new Optimizer();
            pRoot = optimizer.Optimize(pRoot);
            Fire(OnAfterOptimizer, pRoot);
            return pRoot;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Builder()
        {
            _compiler = new Compiler();
        }

        /// <summary>
        /// Compiles all the files in the current build.
        /// </summary>
        public Compiled Build(IEnumerable<string> pDirectories)
        {
            _directories = new List<string>(pDirectories);
            _compiled = new Compiled();
            _directories.ForEach(BuildDirectory);
            return _compiled;
        }

        /// <summary>
        /// Called before optimization.
        /// </summary>
        public event BuildEvent<Node> OnBeforeOptimizer;

        /// <summary>
        /// Before a directory is compiled
        /// </summary>
        public event BuildEvent<string> OnDirectory;

        /// <summary>
        /// Before a file is compiled.
        /// </summary>
        public event BuildEvent<string> OnFile;

        /// <summary>
        /// Called after optimization.
        /// </summary>
        public event BuildEvent<Node> OnAfterOptimizer;
    }
}