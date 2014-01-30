using System.Diagnostics;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Objects;
using Prometheus.Objects.Attributes;

namespace PrometheusTest.Mock
{
    public class MockCommand : PrometheusObject
    {
        /// <summary>
        /// Prints a string to the output.
        /// </summary>
        /// <param name="pValue">The message to print.</param>
        [SymbolHandler(GrammarSymbol.PrintCommand)]
        public Data Print(Data pValue)
        {
            Debug.WriteLine(pValue.Value);

            return Data.Undefined;
        }
    }
}