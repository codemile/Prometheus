using System;
using System.Diagnostics;

namespace Prometheus.Nodes
{
    /// <summary>
    /// The data for a node.
    /// </summary>
    [DebuggerDisplay("{Type}:{Value}")]
    public class Data
    {
        /// <summary>
        /// Represents an undefined data type.
        /// </summary>
        public static readonly Data Undefined = new Data();

        /// <summary>
        /// The data value
        /// </summary>
        public readonly object Value;

        /// <summary>
        /// The data type.
        /// </summary>
        public readonly Type Type;

        /// <summary>
        /// Undefined constructor
        /// </summary>
        private Data()
        {
            Value = null;
            Type = null;
        }

        /// <summary>
        /// Identifier constructor
        /// </summary>
        /// <param name="pIdentifier"></param>
        public Data(Identifier pIdentifier)
        {
            Value = pIdentifier;
            Type = typeof (Identifier);
        }

        /// <summary>
        /// String constructor
        /// </summary>
        /// <param name="pValue">The value</param>
        public Data(string pValue)
        {
            Value = pValue;
            Type = typeof (string);
        }

        /// <summary>
        /// Number constructor
        /// </summary>
        /// <param name="pValue">The value</param>
        public Data(long pValue)
        {
            Value = pValue;
            Type = typeof (long);
        }

        /// <summary>
        /// Decimal constructor
        /// </summary>
        /// <param name="pValue">The value</param>
        public Data(double pValue)
        {
            Value = pValue;
            Type = typeof (double);
        }

        /// <summary>
        /// Boolean constructor
        /// </summary>
        /// <param name="pValue">The value</param>
        public Data(bool pValue)
        {
            Value = pValue;
        }

        /// <summary>
        /// Access the value by a given type. The type will be converted
        /// if conversion is possible.
        /// </summary>
        /// <typeparam name="T">The required type.</typeparam>
        /// <returns>The converted value.</returns>
        public T Get<T>()
        {
            return (Value is T) ? (T)Value : (T)Convert.ChangeType(Value, typeof (T));
        }

        /// <summary>
        /// Access the value as an identifier.
        /// </summary>
        /// <returns>The identifier</returns>
        public Identifier getIdentifier()
        {
            return (Identifier)Value;
        }
    }
}