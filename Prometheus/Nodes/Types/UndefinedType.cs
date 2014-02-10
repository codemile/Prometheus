using System.Diagnostics;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Represents an undefined value.
    /// </summary>
    [DebuggerDisplay("Undefined")]
    public class UndefinedType : iDataType
    {
        /// <summary>
        /// For quick usage.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static readonly UndefinedType UNDEFINED = new UndefinedType();
    }
}