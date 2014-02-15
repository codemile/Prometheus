using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Storage
{
    /// <summary>
    /// Boxes a reference to a memory space location.
    /// </summary>
    public struct MemoryPointer : iVariablePointer
    {
        /// <summary>
        /// The position in the storage
        /// </summary>
        private readonly string _id;

        /// <summary>
        /// The storage space
        /// </summary>
        private readonly iMemorySpace _space;

        /// <summary>
        /// Constructor
        /// </summary>
        public MemoryPointer(iMemorySpace pSpace, string pID) : this()
        {
            _space = pSpace;
            _id = pID;
        }

        /// <summary>
        /// Reads the value
        /// </summary>
        public DataType Read()
        {
            return _space.Get(_id);
        }

        /// <summary>
        /// Writes over the value.
        /// </summary>
        public bool Write(DataType pValue)
        {
            return _space.Set(_id, pValue);
        }
    }
}