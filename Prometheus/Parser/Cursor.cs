using System;
using Prometheus.Exceptions.Executor;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Objects;
using Prometheus.Properties;
using Prometheus.Storage;

namespace Prometheus.Parser
{
    /// <summary>
    /// The currently executing cursor. Holds the current state of the parser.
    /// </summary>
    public class Cursor : IDisposable
    {
        /// <summary>
        /// The storage of all objects.
        /// </summary>
        public readonly HeapSpace Heap;

        /// <summary>
        /// All the object declarations.
        /// </summary>
        public readonly NameSpace Packages;

        /// <summary>
        /// The current node being executed.
        /// </summary>
        public Node Node;

        /// <summary>
        /// The current stack of local variables.
        /// </summary>
        public MemorySpace Stack;

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

        /// <summary>
        /// Gets the value for a qualified identifier.
        /// </summary>
        public DataType Get(QualifiedType pID)
        {
            MemorySpace memory = Resolve(pID);
            DataType dataType = memory.Get(pID.Parts[pID.Parts.Length - 1]);
            if (dataType == null)
            {
                throw new IdentifierInnerException(string.Format(Errors.IdentifierNotDefined, pID));
            }
            return dataType;
        }

        /// <summary>
        /// Resolves the path to a qualified data member.
        /// </summary>
        /// <param name="pID">The qualified ID</param>
        /// <returns></returns>
        public MemorySpace Resolve(QualifiedType pID)
        {
            MemorySpace memory = Stack;
            int index = 0;
            int count = pID.Parts.Length - 1;
            while (index < count)
            {
                DataType dataType = memory.Get(pID.Parts[index]);
                if (dataType == null)
                {
                    throw new IdentifierInnerException(string.Format(Errors.IdentifierNotDefined, pID));
                }
                AliasType a = memory.Get(pID.Parts[index]).getAlias();
                Instance inst = Heap.Get(a);
                memory = inst.Members;
                index++;
            }
            return memory;
        }

        /// <summary>
        /// Sets a value for a qualified identifier.
        /// </summary>
        public void Set(QualifiedType pID, DataType pValue)
        {
            MemorySpace memory = Resolve(pID);
            memory.Assign(pID.Parts[pID.Parts.Length - 1], pValue);
        }
    }
}