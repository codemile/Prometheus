using System.Diagnostics;
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
            Debug.WriteLine(pValue.Get<string>());

            return Data.Undefined;
        }
    }
}