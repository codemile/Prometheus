using System.Collections.Generic;
using System.Linq;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Holds an array of values.
    /// </summary>
    public class ArrayType : DataType
    {
        /// <summary>
        /// Values
        /// </summary>
        public readonly List<DataType> Values;

        /// <summary>
        /// Constructor
        /// </summary>
        public ArrayType()
        {
            Values = new List<DataType>();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return "[" + string.Join(",", from value in Values select value.ToString()) + "]";
        }
    }
}