using System.Diagnostics;
using Prometheus.Nodes.Types.Attributes;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Represents an undefined value.
    /// </summary>
    [DebuggerDisplay("Undefined")]
    [DataTypeInfo("Undefined")]
    public class UndefinedType : DataType
    {
        /// <summary>
        /// Represents an undefined data type.
        /// </summary>
        public static readonly UndefinedType Undefined = new UndefinedType();

        /// <summary>
        /// Debug message
        /// </summary>
        public override string ToString()
        {
            return "undefined";
        }
    }
}