using GOLD;
using Prometheus.Compile;
using Prometheus.Grammar;

namespace Prometheus.Exceptions
{
    public class UnsupportedSymbolException : CompilerException
    {
        /// <summary>
        /// Throw a message.
        /// </summary>
        public UnsupportedSymbolException(GrammarSymbol pSymbol, Cursor pCursor)
            : base(string.Format("Symbol {0} is not supported", pSymbol), pCursor)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public UnsupportedSymbolException(Symbol pSymbol, Cursor pCursor)
            : base(string.Format("Symbol {0} is not supported", ((GrammarSymbol)pSymbol.TableIndex())), pCursor)
        {
        }
    }
}