using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Boxes a boolean value.
    /// </summary>
    public class BooleanType : DataType
    {
        /// <summary>
        /// False constant.
        /// </summary>
        public static readonly BooleanType False = new BooleanType(false);

        /// <summary>
        /// True constant.
        /// </summary>
        public static readonly BooleanType True = new BooleanType(true);

        /// <summary>
        /// The value
        /// </summary>
        public readonly bool Value;

        /// <summary>
        /// Constructor
        /// </summary>
        public BooleanType(bool pValue)
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
            return Value ? "true" : "false";
        }
    }
}