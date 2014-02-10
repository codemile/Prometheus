using System.Globalization;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Holds a reference to an object in the heap.
    /// </summary>
    public class Alias
    {
        /// <summary>
        /// Position of object in the heap.
        /// </summary>
        public readonly int Heap;

        /// <summary>
        /// Constructor
        /// </summary>
        public Alias(int pHeap)
        {
            Heap = pHeap;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return Heap.ToString(CultureInfo.InvariantCulture);
        }
    }
}