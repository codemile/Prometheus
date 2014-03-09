using System.Diagnostics;
using Prometheus.Grammar;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Represents the type info for data.
    /// </summary>
    [DebuggerDisplay("{{Type}}")]
    public class TerminalType : DataType
    {
        /// <summary>
        /// The type as a string.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Constructor
        /// </summary>
        public TerminalType(GrammarSymbol pType)
        {
            Name = pType.ToString().ToLower();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public TerminalType(string pName)
        {
            Name = pName.ToLower();
        }

        /// <summary>
        /// The type as a string.
        /// </summary>
        public override string ToString()
        {
            return Name;
        }
    }
}