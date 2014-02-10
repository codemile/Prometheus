using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Holds a long value
    /// </summary>
    public class IntegerType : iDataType
    {
        /// <summary>
        /// The value
        /// </summary>
        public readonly long Value;

        /// <summary>
        /// Constructor
        /// </summary>
        public IntegerType(long pValue)
        {
            Value = pValue;
        }
    }
}