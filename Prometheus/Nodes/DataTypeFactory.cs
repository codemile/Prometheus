using System;
using System.Collections.Generic;
using Prometheus.Compile;
using Prometheus.Exceptions.Compiler;
using Prometheus.Grammar;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes
{
    /// <summary>
    /// Handles create data objects during compile time.
    /// </summary>
    public static class DataTypeFactory
    {
        /// <summary>
        /// A list of symbols that represent terminals that indicate a data type.
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _dataTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.StringDouble,
                                                                        GrammarSymbol.StringSingle,
                                                                        GrammarSymbol.Number,
                                                                        GrammarSymbol.Decimal,
                                                                        GrammarSymbol.Boolean,
                                                                        GrammarSymbol.Identifier,
                                                                        GrammarSymbol.Type,
                                                                        GrammarSymbol.QualifiedID,
                                                                        GrammarSymbol.ValidID,
                                                                        GrammarSymbol.MemberName
                                                                    };

        /// <summary>
        /// Creates a data object and adjusts the value is needed.
        /// </summary>
        public static DataType Create(Location pLocation, GrammarSymbol pSymbol, string pValue)
        {
            switch (pSymbol)
            {
                    // drop the quotes
                case GrammarSymbol.StringDouble:
                case GrammarSymbol.StringSingle:
                    return new StringType(pValue.Substring(1, pValue.Length - 2));

                case GrammarSymbol.Number:
                    return new NumericType(Convert.ToInt64(pValue));

                case GrammarSymbol.Decimal:
                    return new NumericType(Convert.ToDouble(pValue));

                case GrammarSymbol.Boolean:
                    pValue = pValue.ToLower();
                    switch (pValue)
                    {
                        case "true":
                        case "on":
                        case "yes":
                        case "always":
                            return new BooleanType(true);
                        case "false":
                        case "off":
                        case "no":
                        case "never":
                            return new BooleanType(false);
                    }
                    break;

                case GrammarSymbol.Identifier:
                    return new IdentifierType(pValue);

                case GrammarSymbol.MemberName:
                    return new IdentifierType(pValue.Substring(1));

                case GrammarSymbol.Type:
                    return new StaticType(pValue);
            }

            throw new UnsupportedDataTypeException(string.Format("{0} is not a supported data type.", pSymbol),
                pLocation);
        }

        /// <summary>
        /// Checks if a symbol is a data type.
        /// </summary>
        public static bool isDataType(GrammarSymbol pSymbol)
        {
            return _dataTypes.Contains(pSymbol);
        }
    }
}