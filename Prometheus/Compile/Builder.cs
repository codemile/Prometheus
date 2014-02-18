using System.Collections.Generic;
using System.Linq;
using Prometheus.Compile.Optomizer;
using Prometheus.Compile.Packaging;
using Prometheus.Nodes;
using Prometheus.Packages;

namespace Prometheus.Compile
{
    /// <summary>
    /// </summary>
    public class Builder
    {
        /// <summary>
        /// Callback during the build process.
        /// </summary>
        /// <param name="pNode"></param>
        public delegate void BuildEvent(Node pNode);

        /// <summary>
        /// Handles compiling code.
        /// </summary>
        private readonly Compiler _compiler;

        /// <summary>
        /// List of classes that have been compiled.
        /// </summary>
        private readonly HashSet<ClassNameType> _done;

        /// <summary>
        /// The package loaders.
        /// </summary>
        private readonly MultiLoader _loader;

        /// <summary>
        /// A list of classes waiting to be compiled.
        /// </summary>
        private readonly Queue<ClassNameType> _queue;

        /// <summary>
        /// Handles compiling
        /// </summary>
        private IEnumerable<ClassNameType> Build(Package pPackage, iPackageReader pReader)
        {
            string fileName = pReader.FileName();
            string contents = pReader.Read();

            Node root = _compiler.Compile(fileName, contents);
            root = Optimize(root);
            Compiled code = new Compiled(null, root);
            pPackage.Add(code);

            return code.Uses;
        }

        /// <summary>
        /// Builds the next class or package in the queue.
        /// </summary>
        private void BuildNext(Package pPackage)
        {
            if (_queue.Count == 0)
            {
                return;
            }

            ClassNameType className = _queue.Dequeue();
            IList<iPackageReader> readers = _loader.Load(className) ?? new List<iPackageReader>();
            foreach (iPackageReader reader in readers)
            {
                ClassNameType current = reader.ClassName();
                if (_done.Contains(current))
                {
                    continue;
                }

                IEnumerable<ClassNameType> uses = Build(pPackage, reader);

                _done.Add(current);
                uses.Where(pUsed=>!_done.Contains(pUsed)).ToList().ForEach(_queue.Enqueue);
            }
        }

        /// <summary>
        /// Optimizes the compiled node tree to a structure the parser can
        /// read and make assumptions about.
        /// </summary>
        private Node Optimize(Node pRoot)
        {
            if (BeforeOptimizer != null)
            {
                BeforeOptimizer(pRoot);
            }

            Optimizer optimizer = new Optimizer();
            pRoot = optimizer.Optimize(pRoot);

            if (AfterOptimizer != null)
            {
                AfterOptimizer(pRoot);
            }

            return pRoot;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Builder(MultiLoader pLoader)
        {
            _loader = pLoader;
            _done = new HashSet<ClassNameType>();
            _queue = new Queue<ClassNameType>();
            _compiler = new Compiler();
        }

        /// <summary>
        /// Starts the build process by compiled a class, and branching
        /// out from there.
        /// </summary>
        /// <param name="pClassName">The class to build</param>
        public Package Start(ClassNameType pClassName)
        {
            Package built = new Package(pClassName.Members.First());
            _queue.Enqueue(pClassName);
            BuildNext(built);
            return built;
        }

        /// <summary>
        /// Called before optimization.
        /// </summary>
        public event BuildEvent BeforeOptimizer;

        /// <summary>
        /// Called after optimization.
        /// </summary>
        public event BuildEvent AfterOptimizer;
    }
}