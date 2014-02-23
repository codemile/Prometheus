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
        public readonly string Name;

        /// <summary>
        /// The storage space
        /// </summary>
        private readonly iMemorySpace _space;

        /// <summary>
        /// Constructor
        /// </summary>
        public MemoryPointer(iMemorySpace pSpace, string pName) : this()
        {
            _space = pSpace;
            Name = pName;
        }

        /// <summary>
        /// Reads the value
        /// </summary>
        public DataType Read()
        {
            DataType value = _space.Get(Name);
            if (value == null)
            {
                throw new IdentifierInnerException(string.Format(Errors.IdentifierNotDefined, Name));
            }
            return value;
        }

        /// <summary>
        /// Writes over the value.
        /// </summary>
        public bool Write(DataType pValue)
        {
            if (_space is CursorSpace)
            {
                return _space.Set(Name, pValue);
            }
            _space.Assign(Name, pValue);
            return true;
        }
    }
}