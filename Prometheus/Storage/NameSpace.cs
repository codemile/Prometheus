using System.Collections.Generic;
using System.Linq;
using Prometheus.Exceptions.Executor;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Storage
{
    /// <summary>
    /// Handles storage of packages, and the object declarations in those packages.
    /// </summary>
    public class NameSpace : DataType, iMemorySpace
    {
        /// <summary>
        /// Holds references to sub-packages via their name.
        /// </summary>
        private readonly Dictionary<string, DataType> _space;

        /// <summary>
        /// Constructor
        /// </summary>
        public NameSpace()
        {
            _space = new Dictionary<string, DataType>();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _space.Clear();
        }

        /// <summary>
        /// Derived classes will handle the printing.
        /// </summary>
        public IEnumerable<MemoryItem> Dump()
        {
            return _space.Select(pItem=>new MemoryItem {Name = pItem.Key, Data = pItem.Value});
        }

        /// <summary>
        /// Assigns a value to a name. Creates the a new
        /// variable if required.
        /// </summary>
        /// <param name="pName">The name to create</param>
        /// <param name="pDataType">The data to assign</param>
        public void Assign(string pName, DataType pDataType)
        {
            throw new NameSpaceException("Can not modify namespace declarations at runtime.");
        }

        /// <summary>
        /// Creates a new variable in the current scope.
        /// </summary>
        /// <param name="pName">The name to create</param>
        /// <param name="pDataType">The data to assign</param>
        public void Create(string pName, DataType pDataType)
        {
            if (_space.ContainsKey(pName))
            {
                throw new NameSpaceException(string.Format("Namespace identity <{0}> already exists.", pName));
            }
            _space.Add(pName, pDataType);
        }

        /// <summary>
        /// Derived classes will handle the lookup of an identifier.
        /// </summary>
        /// <param name="pName">The name to get</param>
        /// <returns>The data</returns>
        public DataType Get(string pName)
        {
            if (_space.ContainsKey(pName))
            {
                return _space[pName];
            }
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Checks if the storage contains a variable.
        /// </summary>
        /// <param name="pName">The name to create</param>
        /// <returns>True if exists</returns>
        public bool Has(string pName)
        {
            return _space.ContainsKey(pName);
        }

        /// <summary>
        /// Derived classes will handle the setting.
        /// </summary>
        /// <param name="pName">The name to set</param>
        /// <param name="pDataType">The data</param>
        /// <returns>True if name exists</returns>
        public bool Set(string pName, DataType pDataType)
        {
            throw new NameSpaceException("Can not modify namespace declarations at runtime.");
        }

        /// <summary>
        /// Removes a variable from the current scope.
        /// </summary>
        /// <param name="pName">The name to remove</param>
        public bool Unset(string pName)
        {
            throw new NameSpaceException("Can not unset namespace declarations at runtime.");
        }
    }
}