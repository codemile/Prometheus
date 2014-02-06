using Prometheus.Storage;

namespace Prometheus.Objects
{
    /// <summary>
    /// Holds the data associated with an instance of an object.
    /// </summary>
    public class Instance
    {
        /// <summary>
        /// Members of this object
        /// </summary>
        public readonly MemorySpace Members;

        /// <summary>
        /// The number of references to this instance.
        /// </summary>
        public int References;

        /// <summary>
        /// Constructor
        /// </summary>
        public Instance()
        {
            References = 0;
            Members = new MemorySpace();
        }
    }
}