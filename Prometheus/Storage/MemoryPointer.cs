using Prometheus.Exceptions.Executor;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Properties;

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
            DataType value = _space.Get(_id);
            if (value == null)
            {
                throw new IdentifierInnerException(string.Format(Errors.IdentifierNotDefined, _id));
            }
            return value;
        }

        /// <summary>
        /// Writes over the value.
        /// </summary>
        public bool Write(DataType pValue)
        {
            if (_space is StackSpace)
            {
                return _space.Set(_id, pValue);
            }
            _space.Assign(_id, pValue);
            return true;
        }
    }
}