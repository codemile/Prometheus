using System.Collections.Generic;

namespace Prometheus.Storage
{
    /// <summary>
    /// Objects that contain a list of data should implement this for reporting
    /// their contents.
    /// </summary>
    public interface iMemoryDump
    {
        /// <summary>
        /// Derived classes will handle the printing.
        /// </summary>
        IEnumerable<MemoryItem> Dump();
    }
}