using Logging;
using Prometheus.Executors;
using Prometheus.Executors.Attributes;
using Prometheus.Grammar;
using Prometheus.Nodes.Types;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Prints a string to the output.
    /// </summary>
    public class PrintCommand : ExecutorGrammar
    {
        /// <summary>
        /// Logging
        /// </summary>
        private static readonly Logger _logger = Logger.Create(typeof (PrintCommand));

        /// <summary>
        /// Constructor
        /// </summary>
        public PrintCommand(Executor pExecutor)
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
            _logger.Fine(pValue.GetString());

            return Data.Undefined;
        }
    }
}