using Prometheus.Grammar;
using Prometheus.Nodes.Types;
using Prometheus.Parser;
using Prometheus.Runtime.Creators;

namespace Prometheus.Runtime
{
    /// <summary>
    /// </summary>
    public class Functions : PrometheusObject
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Functions(Cursor pCursor)
            : base(pCursor)
        {
        }

        /// <summary>
        /// Executes an identify as a function.
        /// </summary>
        /// <returns></returns>
        [SymbolHandler(GrammarSymbol.CallExpression)]
        public Data Call(Data pIndentifier, Data pArguments)
        {
            return new Data("called " + pIndentifier.getIdentifier().Name);
        }

        /// <summary>
        /// Handles passing arguments to the call method.
        /// </summary>
        [SymbolHandler(GrammarSymbol.ArgumentList)]
        public Data Arguments()
        {
            return Data.Undefined;
        }

        /// <summary>
        /// Handles passing arguments to the call method.
        /// </summary>
        [SymbolHandler(GrammarSymbol.ArgumentList)]
        public Data Arguments(Data pArg1)
        {
            return new Data(new ArgumentList {pArg1});
        }

        /// <summary>
        /// Handles passing arguments to the call method.
        /// </summary>
        [SymbolHandler(GrammarSymbol.ArgumentList)]
        public Data Arguments(Data pArg1, Data pArg2)
        {
            return new Data(new ArgumentList {pArg1, pArg2});
        }

    }
}