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
        private readonly int _heap;

        /// <summary>
        /// Constructor
        /// </summary>
        public Alias(int pHeap)
        {
            _heap = pHeap;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return _heap.ToString(CultureInfo.InvariantCulture);
        }
    }
}