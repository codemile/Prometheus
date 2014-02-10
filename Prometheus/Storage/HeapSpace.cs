using System;
using System.Collections.Generic;
using Prometheus.Exceptions.Executor;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Objects;

namespace Prometheus.Storage
{
    /// <summary>
    /// Stores all the objects
    /// </summary>
    public class HeapSpace : IDisposable
    {
        /// <summary>
        /// How much to pre-allocate heap.
        /// </summary>
        private const int _HEAP_SIZE = 50000;

        /// <summary>
        /// Storage of run-time objects.
        /// </summary>
        private readonly List<Instance> _storage;

        /// <summary>
        /// Constructor
        /// </summary>
        public HeapSpace()
        {
            _storage = new List<Instance>(_HEAP_SIZE);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _storage.Clear();
        }

        /// <summary>
        /// Adds an object to the heap.
        /// </summary>
        /// <param name="pInstance">The instance of the object.</param>
        /// <returns>An alias pointing to the object.</returns>
        public DataType Add(Instance pInstance)
        {
            _storage.Add(pInstance);
            return new DataType(new AliasType(_storage.Count - 1));
        }

        /// <summary>
        /// Access an object instance by it's alias.
        /// </summary>
        /// <param name="pAliasType">The alias</param>
        /// <returns>The instance</returns>
        public Instance Get(AliasType pAliasType)
        {
            if (pAliasType.Heap >= _storage.Count)
            {
                throw new UnexpectedErrorException("Memory location no longer refers to object.");
            }
            return _storage[pAliasType.Heap];
        }
    }
}