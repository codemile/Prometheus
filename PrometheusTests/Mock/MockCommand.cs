using System.Diagnostics;
using Prometheus.Grammar;
using Prometheus.Nodes.Types;
using Prometheus.Parser;
using Prometheus.Runtime.Creators;

namespace PrometheusTest.Mock
{
    public class MockCommand : PrometheusObject
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MockCommand(Executor pExecutor)
            : base(pExecutor)
        {
        }

        /// <summary>
        /// Prints a string to the output.
        /// </summary>
        /// <param name="pValue">The message to print.</param>
        [SymbolHandler(GrammarSymbol.PrintProc)]
        public Data Print(Data pValue)
        {
            Debug.WriteLine(pValue.GetString());

            return Data.Undefined;
        }
    }
}