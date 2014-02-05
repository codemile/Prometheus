using System;
using Prometheus.Nodes;
using Prometheus.Objects;
using Prometheus.Storage;

namespace Prometheus.Parser
{
    /// <summary>
    /// The currently executing cursor. Holds the current state of the parser.
    /// </summary>
    public class Cursor : IDisposable
    {
        /// <summary>
        /// The current node being executed.
        /// </summary>
        public Node Node;

        /// <summary>
        /// The current stack of local variables.
        /// </summary>
        public StackSpace Stack;

        /// <summary>
        /// The storage of all objects.
        /// </summary>
        public readonly HeapSpace Heap;

        /// <summary>
        /// All the object declarations.
        /// </summary>
        public readonly NameSpace Packages;

        /// <summary>
        /// Constructor
        /// </summary>
        public Cursor()
        {
            Stack = null;
            Node = null;

            Heap = new HeapSpace();
            Packages = new NameSpace();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (Stack != null)
            {
                Stack.Dispose();
            }
            Heap.Dispose();
            Packages.Dispose();
            Node = null;
        }
    }
}