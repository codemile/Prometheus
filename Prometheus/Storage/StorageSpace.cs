using System.Collections.Generic;
using System.Linq;
using Prometheus.Exceptions.Executor;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Properties;

namespace Prometheus.Storage
{
    /// <summary>
    /// Base class for variable storage.
    /// </summary>
    public class StorageSpace : iMemorySpace
    {
        /// <summary>
        /// Storage of variable values.
        /// </summary>
        private readonly Dictionary<string, DataType> _storage;

        /// <summary>
        /// True if storage is empty.
        /// </summary>
        public bool isEmpty
        {
            get { return _storage.Count == 0; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public StorageSpace()
            : this(new Dictionary<string, DataType>())
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public StorageSpace(Dictionary<string, DataType> pStorage)
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
        /// <param name="pName">The name to get</param>
        /// <returns>The data</returns>
        public virtual DataType Get(string pName)
        {
            return _storage.ContainsKey(pName) ? _storage[pName] : null;
        }

        /// <summary>
        /// Derived classes will handle the setting.
        /// </summary>
        /// <param name="pName">The name to set</param>
        /// <param name="pDataType">The data</param>
        /// <returns>True if name exists</returns>
        public virtual bool Set(string pName, DataType pDataType)
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
        /// <param name="pName">The name to remove</param>
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
        /// Assigns a value to a name. Creates the a new
        /// variable if required.
        /// </summary>
        /// <param name="pName">The name to create</param>
        /// <param name="pDataType">The data to assign</param>
        public void Assign(string pName, DataType pDataType)
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
        /// <param name="pName">The name to create</param>
        /// <param name="pDataType">The data to assign</param>
        public void Create(string pName, DataType pDataType)
        {
            // only check the current scope
            if (_storage.ContainsKey(pName))
            {
                throw new IdentifierInnerException(string.Format(Errors.IdentifierAlreadyDefined, pName));
            }
            _storage.Add(pName, pDataType);
        }

        /// <summary>
        /// Checks if the storage contains a variable.
        /// </summary>
        /// <param name="pName">The name to create</param>
        /// <returns>True if exists</returns>
        public virtual bool Has(string pName)
        {
            return _storage.ContainsKey(pName);
        }

        /// <summary>
        /// Derived classes will handle the printing.
        /// </summary>
        /// <param name="pIndent">Line indent</param>
        public virtual IEnumerable<MemoryItem> Dump(int pIndent = 0)
        {
            return from item in _storage select new MemoryItem {Level = pIndent, Name = item.Key, Data = item.Value};
        }
    }
}