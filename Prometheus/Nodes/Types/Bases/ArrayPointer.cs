namespace Prometheus.Nodes.Types.Bases
{
    /// <summary>
    /// Refers to a position in an array object. The index is assumed to be verified as in range
    /// before this is created.
    /// </summary>
    public struct ArrayPointer : iVariablePointer
    {
        /// <summary>
        /// The array
        /// </summary>
        private readonly ArrayType _array;

        /// <summary>
        /// The offset
        /// </summary>
        private readonly int _index;

        /// <summary>
        /// Constructor
        /// </summary>
        public ArrayPointer(ArrayType pArray, int pIndex) : this()
        {
            _array = pArray;
            _index = pIndex;
        }

        /// <summary>
        /// Reads the value
        /// </summary>
        public DataType Read()
        {
            return _array[_index];
        }

        /// <summary>
        /// Writes over the value.
        /// </summary>
        public bool Write(DataType pValue)
        {
            _array[_index] = pValue;
            return true;
        }

        /// <summary>
        /// Does the pointer reference a valid location.
        /// </summary>
        public bool IsValid()
        {
            return _index >= 0 && _index < _array.Count;
        }
    }
}