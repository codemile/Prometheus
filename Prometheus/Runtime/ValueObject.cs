using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Runtime.Creators;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Holds a static value
    /// </summary>
    // ReSharper disable UnusedMember.Global
    public class ValueObject : PrometheusObject
    {
        /// <summary>
        /// Returns the value of data stored in the source code.
        /// </summary>
        /// <returns></returns>
        [SymbolHandler(GrammarSymbol.Value)]
        public Data Value(Data pValue)
        {
            return pValue;
        }
    }
}