using System;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Runtime.Creators;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Handles basic math operations.
    /// </summary>
    public class MathOperators : PrometheusObject
    {
        /// <summary>
        /// Addition
        /// </summary>
        [SymbolHandler(GrammarSymbol.AddExpression)]
        public Data Add(Data pValue1, Data pValue2)
        {
            Type t1 = pValue1.Type;
            Type t2 = pValue2.Type;
            if (t1 == typeof (string) || t2 == typeof (string))
            {
                return new Data(string.Concat(pValue1.Get<string>(), pValue2.Get<string>()));
            }

            Type type = DataConverter.BestNumericType(t1, t2);
            return type == typeof (long) ? 
                new Data(pValue1.Get<long>() + pValue2.Get<long>()) : 
                new Data(pValue1.Get<double>() + pValue2.Get<double>());
        }

        /// <summary>
        /// Subtraction
        /// </summary>
        [SymbolHandler(GrammarSymbol.SubExpression)]
        public Data Sub(Data pValue1, Data pValue2)
        {
            Type type = DataConverter.BestNumericType(pValue1.Type, pValue2.Type);
            return type == typeof (long)
                ? new Data(pValue1.Get<long>() - pValue2.Get<long>())
                : new Data(pValue1.Get<double>() - pValue2.Get<double>());
        }

        /// <summary>
        /// Multiplication
        /// </summary>
        [SymbolHandler(GrammarSymbol.MultiplyExpression)]
        public Data Mul(Data pValue1, Data pValue2)
        {
            Type type = DataConverter.BestNumericType(pValue1.Type, pValue2.Type);
            return type == typeof(long)
                ? new Data(pValue1.Get<long>() * pValue2.Get<long>())
                : new Data(pValue1.Get<double>() * pValue2.Get<double>());
        }

        /// <summary>
        /// Division
        /// </summary>
        [SymbolHandler(GrammarSymbol.DivideExpression)]
        public Data Div(Data pValue1, Data pValue2)
        {
            return new Data(pValue1.Get<double>() / pValue2.Get<double>());
        }

    }
}