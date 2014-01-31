using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Runtime.Creators;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Implements the operators for greater than and less than.
    /// </summary>
    public class RelationalOperators : PrometheusObject
    {
        /// <summary>
        /// Greater Than
        /// </summary>
        [SymbolHandler(GrammarSymbol.GtOperator)]
        public Data GreaterThan(Data pValue1, Data pValue2)
        {
            Type type = DataConverter.BestNumericType(pValue1.Type, pValue2.Type);
            return type == typeof(long)
                ? new Data(pValue1.Get<long>() > pValue2.Get<long>())
                : new Data(pValue1.Get<double>() > pValue2.Get<double>());
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [SymbolHandler(GrammarSymbol.LtOperator)]
        public Data LessThan(Data pValue1, Data pValue2)
        {
            Type type = DataConverter.BestNumericType(pValue1.Type, pValue2.Type);
            return type == typeof(long)
                ? new Data(pValue1.Get<long>() < pValue2.Get<long>())
                : new Data(pValue1.Get<double>() < pValue2.Get<double>());
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [SymbolHandler(GrammarSymbol.GteOperator)]
        public Data GreaterThanEqual(Data pValue1, Data pValue2)
        {
            Type type = DataConverter.BestNumericType(pValue1.Type, pValue2.Type);
            return type == typeof(long)
                ? new Data(pValue1.Get<long>() >= pValue2.Get<long>())
                : new Data(pValue1.Get<double>() >= pValue2.Get<double>());
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [SymbolHandler(GrammarSymbol.LteOperator)]
        public Data LessThanEqual(Data pValue1, Data pValue2)
        {
            Type type = DataConverter.BestNumericType(pValue1.Type, pValue2.Type);
            return type == typeof(long)
                ? new Data(pValue1.Get<long>() <= pValue2.Get<long>())
                : new Data(pValue1.Get<double>() <= pValue2.Get<double>());
        }
    }
}
