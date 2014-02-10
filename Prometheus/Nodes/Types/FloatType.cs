using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Holds a decimal-precision number.
    /// </summary>
    public class FloatType : iDataType
    {
        /// <summary>
        /// The value
        /// </summary>
        public readonly double Value;

        /// <summary>
        /// Constructor
        /// </summary>
        public FloatType(double pValue)
        {
            Value = pValue;
        }
    }
}