using System;
using System.Collections.Generic;
using Logging;
using Prometheus.Exceptions.Executor;
using Prometheus.Nodes.Types;
using Prometheus.Properties;

namespace Prometheus.Storage
{
    /// <summary>
    /// Base class for variable storage.
    /// </summary>
    public abstract class MemorySpace : IDisposable
    {
        /// <summary>
        /// Logging
        /// </summary>
        private static readonly Logger _logger = Logger.Create(typeof (MemorySpace));

        /// <summary>
        /// Storage of variable values.
        /// </summary>
        public Dictionary<string, Data> Storage { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        protected MemorySpace()
            : this(new Dictionary<string, Data>())
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        protected MemorySpace(Dictionary<string, Data> pStorage)
        {
            Storage = pStorage;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            Storage.Clear();
        }

        /// <summary>
        /// Derived classes will handle the lookup of an identifier.
        /// </summary>
        /// <param name="pIdentifier">The identifier to get</param>
        /// <returns>The data</returns>
        public virtual Data Get(string pIdentifier)
        {
            return Storage.ContainsKey(pIdentifier) ? Storage[pIdentifier] : null;
        }

        /// <summary>
        /// Derived classes will handle the printing.
        /// </summary>
        /// <param name="pIndent">Line indent</param>
        public virtual void Print(int pIndent = 0)
        {
            string indent = string.Format("{0}> ", " ".PadLeft(pIndent));
            foreach (KeyValuePair<string, Data> var in Storage)
            {
                if (var.Value.Type == typeof (string))
                {
                    _logger.Fine("{0}{1} = \"{2}\"", indent, var.Key, var.Value.getString());
                    continue;
                }
                _logger.Fine("{0}{1} = {2}", indent, var.Key, var.Value.getString() ?? "undefined");
            }
        }

        /// <summary>
        /// Derived classes will handle the setting.
        /// </summary>
        /// <param name="pIdentifier">The identifier to set</param>
        /// <param name="pData">The data</param>
        /// <returns>True if identifier exists</returns>
        public virtual bool Set(string pIdentifier, Data pData)
        {
            if (!Storage.ContainsKey(pIdentifier))
            {
                return false;
            }
            Storage[pIdentifier] = pData;
            return true;
        }

        /// <summary>
        /// Creates a new variable in the current scope.
        /// </summary>
        /// <param name="pIdentifier">The identifier to create</param>
        /// <param name="pData">The data to assign</param>
        public void Create(string pIdentifier, Data pData)
        {
            // only check the current scope
            if (Storage.ContainsKey(pIdentifier))
            {
                throw new IdentifierException(Errors.IdentifierAlreadyDefined, pIdentifier);
            }
            Storage.Add(pIdentifier, pData);
        }
    }
}