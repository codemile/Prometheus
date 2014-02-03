using System.Diagnostics;
using Prometheus.Executors;
using Prometheus.Executors.Attributes;
using Prometheus.Grammar;
using Prometheus.Nodes.Types;
using Prometheus.Parser;

namespace PrometheusTest.Mock
{
    public class MockCommand : ExecutorGrammar
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
        [ExecuteSymbol(GrammarSymbol.PrintProc)]
        public Data Print(Data pValue)
        {
            Debug.WriteLine(pValue.GetString());

            return Data.Undefined;
        }
    }
}