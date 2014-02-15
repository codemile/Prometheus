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
        private readonly iMemorySpace _members;

        /// <summary>
        /// Constructor
        /// </summary>
        public Instance(iMemorySpace pMembers)
        {
            _members = pMembers;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Instance()
        {
            _members = new StorageSpace();
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public iMemorySpace GetMembers()
        {
            return _members;
        }
    }
}