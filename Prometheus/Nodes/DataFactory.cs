using Prometheus.Grammar;

namespace Prometheus.Nodes
{
    /// <summary>
    /// Handles create data objects during compile time.
    /// </summary>
    public static class DataFactory
    {
        /// <summary>
        /// Creates a data object and adjusts the value is needed.
        /// </summary>
        public static Data Create(GrammarSymbol pSymbol, string pValue)
        {
            switch (pSymbol)
            {
                    // drop the quotes
                case GrammarSymbol.StringDouble:
                case GrammarSymbol.StringSingle:
                    pValue = pValue.Substring(1, pValue.Length - 2);
                    break;
            }

            return new Data(pSymbol, pValue);
        }
    }
}