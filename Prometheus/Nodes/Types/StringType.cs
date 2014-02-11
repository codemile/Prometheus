using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Boxes string values
    /// </summary>
    public class StringType : DataType
    {
        /// <summary>
        /// String value
        /// </summary>
        public readonly string Value;

        /// <summary>
        /// Constructor
        /// </summary>
        public StringType(string pValue)
        {
            Value = pValue;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return Value;
        }
    }
}