using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Parser;
using Prometheus.Runtime.Creators;

namespace Prometheus.Runtime
{
    /// <summary>
    /// All the string functions
    /// </summary>
    public class StringManipulation : PrometheusObject
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public StringManipulation(Cursor pCursor)
            : base(pCursor)
        {
        }

        /// <summary>
        /// Converts to lower case.
        /// </summary>
        [SymbolHandler(GrammarSymbol.LowerFunc)]
        public Data ToLower(Data pValue)
        {
            return new Data(pValue.GetString().ToLower());
        }

        /// <summary>
        /// Converts to upper case.
        /// </summary>
        [SymbolHandler(GrammarSymbol.UpperFunc)]
        public Data ToUpper(Data pValue)
        {
            return new Data(pValue.GetString().ToUpper());
        }

        /// <summary>
        /// Converts to trims spaces
        /// </summary>
        [SymbolHandler(GrammarSymbol.TrimFunc)]
        public Data Trim(Data pValue)
        {
            return new Data(pValue.GetString().Trim());
        }
    }
}