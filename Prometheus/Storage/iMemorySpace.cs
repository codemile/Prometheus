using System;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Storage
{
    /// <summary>
    /// Handles the storage of variables by name.
    /// </summary>
    public interface iMemorySpace : IDisposable, iMemoryDump
    {
        /// <summary>
        /// Assigns a value to a name. Creates the a new
        /// variable if required.
        /// </summary>
        /// <param name="pName">The name to create</param>
        /// <param name="pDataType">The data to assign</param>
        void Assign(string pName, DataType pDataType);

        /// <summary>
        /// Creates a new variable in the current scope.
        /// </summary>
        /// <param name="pName">The name to create</param>
        /// <param name="pDataType">The data to assign</param>
        void Create(string pName, DataType pDataType);

        /// <summary>
        /// Derived classes will handle the lookup of an identifier.
        /// </summary>
        /// <param name="pName">The name to get</param>
        /// <returns>The data</returns>
        DataType Get(string pName);

        /// <summary>
        /// Checks if the storage contains a variable.
        /// </summary>
        /// <param name="pName">The name to create</param>
        /// <returns>True if exists</returns>
        bool Has(string pName);

        /// <summary>
        /// Derived classes will handle the setting.
        /// </summary>
        /// <param name="pName">The name to set</param>
        /// <param name="pDataType">The data</param>
        /// <returns>True if name exists</returns>
        bool Set(string pName, DataType pDataType);

        /// <summary>
        /// Removes a variable from the current scope.
        /// </summary>
        /// <param name="pName">The name to remove</param>
        bool Unset(string pName);
    }
}