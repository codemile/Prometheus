using Prometheus.Nodes.Types.Bases;
using Prometheus.Storage;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Holds the data associated with an instance of an object.
    /// </summary>
    public class InstanceType : DataType
    {
        /// <summary>
        /// The name of the class this instance represents.
        /// </summary>
        public readonly QualifiedType ClassName;

        /// <summary>
        /// Members of this object
        /// </summary>
        private readonly iMemorySpace _members;

        /// <summary>
        /// Constructor
        /// </summary>
        public InstanceType(QualifiedType pClassName, iMemorySpace pMembers)
        {
            ClassName = pClassName;
            _members = pMembers;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public InstanceType()
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