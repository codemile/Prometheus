using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Objects.Attributes;

namespace Prometheus.Objects
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
        public Data Value()
        {
            return Data.Undefined;
        }
    }
}