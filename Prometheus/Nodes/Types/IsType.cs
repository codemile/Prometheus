using System.Diagnostics;
using Prometheus.Grammar;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Represents the type info for data.
    /// </summary>
    [DebuggerDisplay("{{Type}}")]
    public class IsType : DataType
    {
        /// <summary>
        /// The type as a string.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Constructor
        /// </summary>
        public IsType(GrammarSymbol pType)
        {
            Name = pType.ToString().ToLower();
        }
    }
}