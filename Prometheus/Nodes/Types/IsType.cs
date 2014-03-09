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
        /// The type
        /// </summary>
        public readonly GrammarSymbol Type;

        /// <summary>
        /// Constructor
        /// </summary>
        public IsType(GrammarSymbol pType)
        {
            Type = pType;
        }

        /// <summary>
        /// The type as a string.
        /// </summary>
        public override string ToString()
        {
            return Type.ToString().ToLower();
        }
    }
}