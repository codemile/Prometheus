using Logging;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Parser;
using Prometheus.Runtime.Creators;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Prints a string to the output.
    /// </summary>
    public class PrintCommand : PrometheusObject
    {
        /// <summary>
        /// Logging
        /// </summary>
        private static readonly Logger _logger = Logger.Create(typeof (PrintCommand));

        /// <summary>
        /// Constructor
        /// </summary>
        public PrintCommand(Cursor pCursor)
            : base(pCursor)
        {
        }

        /// <summary>
        /// Prints a string to the output.
        /// </summary>
        /// <param name="pValue">The message to print.</param>
        [SymbolHandler(GrammarSymbol.PrintProc)]
        public Data Print(Data pValue)
        {
            _logger.Fine(pValue.GetString());

            return Data.Undefined;
        }
    }
}