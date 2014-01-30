using System.Diagnostics;
using Prometheus.Grammar;

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
        public static readonly Data Undefined = new Data((GrammarSymbol)(-1), null);

        /// <summary>
        /// The data type.
        /// </summary>
        public readonly GrammarSymbol Type;

        /// <summary>
        /// The data value
        /// </summary>
        public readonly string Value;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pType">The type</param>
        /// <param name="pValue">The value</param>
        public Data(GrammarSymbol pType, string pValue)
        {
            Type = pType;
            Value = pValue;
        }
    }
}