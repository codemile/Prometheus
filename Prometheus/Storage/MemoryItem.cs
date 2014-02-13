using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Storage
{
    /// <summary>
    /// Used to print the contents of the stack.
    /// </summary>
    public class MemoryItem
    {
        /// <summary>
        /// The data for the variable.
        /// </summary>
        public DataType Data;

        /// <summary>
        /// The nested level of the stack.
        /// </summary>
        public int Level;

        /// <summary>
        /// The name of the variable.
        /// </summary>
        public string Name;
    }
}