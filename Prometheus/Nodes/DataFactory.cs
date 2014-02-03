using System;
using Prometheus.Compile;
using Prometheus.Exceptions.Compiler;
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
        public static Data Create(Location pLocation, GrammarSymbol pSymbol, string pValue)
        {
            switch (pSymbol)
            {
                    // drop the quotes
                case GrammarSymbol.StringDouble:
                case GrammarSymbol.StringSingle:
                    return new Data(pValue.Substring(1, pValue.Length - 2));

                case GrammarSymbol.Number:
                    return new Data(Convert.ToInt64(pValue));

                case GrammarSymbol.Decimal:
                    return new Data(Convert.ToDouble(pValue));

                case GrammarSymbol.Boolean:
                    pValue = pValue.ToLower();
                    switch (pValue)
                    {
                        case "true":
                        case "on":
                        case "yes":
                        case "always":
                            return new Data(true);
                        case "false":
                        case "off":
                        case "no":
                        case "never":
                            return new Data(false);
                    }
                    break;

                case GrammarSymbol.Identifier:
                    return new Data(new Identifier(pValue));
            }

            throw new UnsupportedDataTypeException(string.Format("{0} is not a supported data type.", pSymbol),
                pLocation);
        }
    }
}