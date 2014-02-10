using System.Diagnostics;
using Prometheus.Grammar;
using Prometheus.Nodes.Types;
using Prometheus.Parser.Executors;
using Prometheus.Parser.Executors.Attributes;

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
        public void Print(String pValue)
        {
            Debug.WriteLine(pValue.Value);
        }
    }
}