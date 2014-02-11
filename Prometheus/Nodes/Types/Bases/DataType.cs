using System.Diagnostics;
using Prometheus.Exceptions.Executor;

namespace Prometheus.Nodes.Types.Bases
{
    /// <summary>
    /// The data for a node.
    /// </summary>
    [DebuggerDisplay("{Type}:{_value}")]
    public abstract class DataType
    {
        /// <summary>
        /// Represents an undefined data type.
        /// </summary>
        public static readonly UndefinedType Undefined = new UndefinedType();

        /// <summary>
        /// Attempts to convert this type to boolean.
        /// </summary>
        /// <returns>Boolean value</returns>
        public bool getBool()
        {
            if (GetType() == typeof (BooleanType))
            {
                return ((BooleanType)this).Value;
            }
            if (GetType() == typeof (NumericType))
            {
                NumericType num = (NumericType)this;
                if (num.Type == typeof (long))
                {
                    return (long)num.Value != 0;
                }
            }

            throw new DataTypeException(string.Format("Cannot convert <{0}> to boolean", GetType().FullName));
        }
    }
}