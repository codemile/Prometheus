using System;
using System.Diagnostics;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// The data for a node.
    /// </summary>
    [DebuggerDisplay("{Type}:{_value}")]
    public class Data
    {
        /// <summary>
        /// The floating point degree of error.
        /// </summary>
        public const double PRECISE_EPSILON = double.Epsilon;

        /// <summary>
        /// The non-decimal type for the engine.
        /// </summary>
        public static readonly Type Integer = typeof (long);

        /// <summary>
        /// The floating point type for the engine.
        /// </summary>
        public static readonly Type Precise = typeof (double);

        /// <summary>
        /// Represents an undefined data type.
        /// </summary>
        public static readonly Data Undefined = new Data();

        /// <summary>
        /// The data type.
        /// </summary>
        public readonly Type Type;

        /// <summary>
        /// The data value
        /// </summary>
        private readonly object _value;

        /// <summary>
        /// Access the value by a given type. The type will be converted
        /// if conversion is possible.
        /// </summary>
        /// <typeparam name="T">The required type.</typeparam>
        /// <returns>The converted value.</returns>
        private T Get<T>()
        {
            return (_value is T)
                ? (T)_value
                : (T)Convert.ChangeType(_value, typeof (T));
        }

        /// <summary>
        /// Undefined constructor
        /// </summary>
        private Data()
        {
            _value = new Undefined();
            Type = typeof (Undefined);
        }

        /// <summary>
        /// Function expression
        /// </summary>
        public Data(Node pNode)
        {
            _value = pNode;
            Type = typeof (Node);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Data(ArgumentList pArguments)
        {
            _value = pArguments;
            Type = typeof (ArgumentList);
        }

        /// <summary>
        /// Identifier constructor
        /// </summary>
        /// <param name="pIdentifier"></param>
        public Data(Identifier pIdentifier)
        {
            _value = pIdentifier;
            Type = typeof (Identifier);
        }

        /// <summary>
        /// String constructor
        /// </summary>
        /// <param name="pValue">The value</param>
        public Data(string pValue)
        {
            _value = pValue;
            Type = typeof (string);
        }

        /// <summary>
        /// Number constructor
        /// </summary>
        /// <param name="pValue">The value</param>
        public Data(long pValue)
        {
            _value = pValue;
            Type = typeof (long);
        }

        /// <summary>
        /// Decimal constructor
        /// </summary>
        /// <param name="pValue">The value</param>
        public Data(double pValue)
        {
            _value = pValue;
            Type = typeof (double);
        }

        /// <summary>
        /// Boolean constructor
        /// </summary>
        /// <param name="pValue">The value</param>
        public Data(bool pValue)
        {
            _value = pValue;
            Type = typeof (bool);
        }

        /// <summary>
        /// Converts the data to a debug message.
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0}:{1}", Type.Name, _value);
        }

        /// <summary>
        /// Access the data as a boolean
        /// </summary>
        /// <returns>The converted value.</returns>
        public bool GetBool()
        {
            return Type == typeof (Node) || Get<bool>();
        }

        /// <summary>
        /// Access the data as an integer value.
        /// </summary>
        /// <returns>The converted value.</returns>
        public long GetInteger()
        {
            return (Type == Integer)
                ? (long)_value
                : Get<long>();
        }

        /// <summary>
        /// Access the data as a floating point value.
        /// </summary>
        /// <returns>The converted value.</returns>
        public double GetPrecise()
        {
            return (Type == Precise)
                ? (double)_value
                : Get<double>();
        }

        /// <summary>
        /// Access the data as a string.
        /// </summary>
        /// <returns>The converted value.</returns>
        public string GetString()
        {
            return Type == typeof (Node) ? "function" : Get<string>();
        }

        /// <summary>
        /// Access the value as an identifier.
        /// </summary>
        /// <returns>The identifier</returns>
        public Identifier getIdentifier()
        {
            return (Identifier)_value;
        }
    }
}