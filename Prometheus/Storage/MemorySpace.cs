using System;
using System.Collections.Generic;
using Logging;
using Prometheus.Exceptions.Executor;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Properties;

namespace Prometheus.Storage
{
    /// <summary>
    /// Base class for variable storage.
    /// </summary>
    public class MemorySpace : IDisposable
    {
        /// <summary>
        /// Logging
        /// </summary>
        private static readonly Logger _logger = Logger.Create(typeof (MemorySpace));

        /// <summary>
        /// Storage of variable values.
        /// </summary>
        private readonly Dictionary<string, iDataType> _storage;

        /// <summary>
        /// Constructor
        /// </summary>
        public MemorySpace()
            : this(new Dictionary<string, iDataType>())
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        protected MemorySpace(Dictionary<string, iDataType> pStorage)
        {
            _storage = pStorage;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            _storage.Clear();
        }

        /// <summary>
        /// Derived classes will handle the lookup of an identifier.
        /// </summary>
        /// <param name="pName">The identifier to get</param>
        /// <returns>The data</returns>
        public virtual iDataType Get(string pName)
        {
            return _storage.ContainsKey(pName) ? _storage[pName] : null;
        }

        /// <summary>
        /// Derived classes will handle the printing.
        /// </summary>
        /// <param name="pIndent">Line indent</param>
        public virtual void Print(int pIndent = 0)
        {
            string indent = string.Format("{0}> ", " ".PadLeft(pIndent));
            foreach (KeyValuePair<string, iDataType> var in _storage)
            {
                StringType str = var.Value as StringType;
                if (str != null)
                {
                    _logger.Fine("{0}{1} = \"{2}\"", indent, var.Key, str.Value);
                    continue;
                }
                _logger.Fine("{0}{1} = {2}", indent, var.Key, var.Value.ToString());
            }
        }

        /// <summary>
        /// Derived classes will handle the setting.
        /// </summary>
        /// <param name="pName">The identifier to set</param>
        /// <param name="pDataType">The data</param>
        /// <returns>True if identifier exists</returns>
        public virtual bool Set(string pName, iDataType pDataType)
        {
            if (!_storage.ContainsKey(pName))
            {
                return false;
            }
            _storage[pName] = pDataType;
            return true;
        }

        /// <summary>
        /// Removes a variable from the current scope.
        /// </summary>
        /// <param name="pName">The identifier to remove</param>
        public virtual bool Unset(string pName)
        {
            if (!_storage.ContainsKey(pName))
            {
                return false;
            }
            _storage.Remove(pName);
            return true;
        }

        /// <summary>
        /// Assigns a value to an identifier. Creates the a new
        /// variable if required.
        /// </summary>
        /// <param name="pName">The identifier to create</param>
        /// <param name="pDataType">The data to assign</param>
        public void Assign(string pName, iDataType pDataType)
        {
            if (_storage.ContainsKey(pName))
            {
                _storage[pName] = pDataType;
            }
            else
            {
                _storage.Add(pName, pDataType);
            }
        }

        /// <summary>
        /// Creates a new variable in the current scope.
        /// </summary>
        /// <param name="pName">The identifier to create</param>
        /// <param name="pDataType">The data to assign</param>
        public void Create(string pName, iDataType pDataType)
        {
            // only check the current scope
            if (_storage.ContainsKey(pName))
            {
                throw new IdentifierInnerException(string.Format(Errors.IdentifierAlreadyDefined, pName));
            }
            _storage.Add(pName, pDataType);
        }
    }
}