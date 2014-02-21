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
        /// Access as double
        /// </summary>
        public double Double
        {
            get { return Convert.ToDouble(Value); }
        }

        /// <summary>
        /// Access as long
        /// </summary>
        public long Long
        {
            get { return Convert.ToInt64(Value); }
        }

        /// <summary>
        /// is double type
        /// </summary>
        public bool isDouble
        {
            get { return Value is double; }
        }

        /// <summary>
        /// is long type
        /// </summary>
        public bool isLong
        {
            get { return Value is long; }
        }

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
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return Value + (isDouble ? "f":"");
        }
    }
}