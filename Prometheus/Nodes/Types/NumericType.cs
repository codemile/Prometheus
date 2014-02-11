using System;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Boxes primitive types
    /// </summary>
    public class NumericType : DataType
    {
        /// <summary>
        /// The primitive type
        /// </summary>
        public readonly Type Type;

        /// <summary>
        /// The raw value
        /// </summary>
        public readonly object Value;

        /// <summary>
        /// Long constructor
        /// </summary>
        public NumericType(long pValue)
        {
            Value = pValue;
            Type = typeof (long);
        }

        /// <summary>
        /// Double constructor
        /// </summary>
        public NumericType(double pValue)
        {
            Value = pValue;
            Type = typeof (double);
        }

        /// <summary>
        /// Access as double
        /// </summary>
        public double getDouble()
        {
            return (double)Value;
        }

        /// <summary>
        /// Access as long
        /// </summary>
        public long getLong()
        {
            return (long)Value;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}