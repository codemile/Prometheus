using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Runtime.Creators;

namespace Prometheus.Runtime
{
    /// <summary>
    /// All the string functions
    /// </summary>
    public class StringManipulation : PrometheusObject
    {
        /// <summary>
        /// Converts to upper case.
        /// </summary>
        [SymbolHandler(GrammarSymbol.UpperFunc)]
        public Data ToUpper(Data pValue)
        {
            return new Data(pValue.Get<string>().ToUpper());
        }

        /// <summary>
        /// Converts to lower case.
        /// </summary>
        [SymbolHandler(GrammarSymbol.LowerFunc)]
        public Data ToLower(Data pValue)
        {
            return new Data(pValue.Get<string>().ToLower());
        }

        /// <summary>
        /// Converts to trims spaces
        /// </summary>
        [SymbolHandler(GrammarSymbol.TrimFunc)]
        public Data Trim(Data pValue)
        {
            return new Data(pValue.Get<string>().Trim());
        }
    }
}