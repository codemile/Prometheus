using GOLD;
using Prometheus.Documents;

namespace Prometheus.Exceptions
{
    public class UnsupportedSymbolException : CompilerException
    {
        /// <summary>
        /// Throw a message.
        /// </summary>
        public UnsupportedSymbolException(ParserSymbol pSymbol, Cursor pCursor)
            : base(string.Format("Symbol {0} is not supported", pSymbol), pCursor)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public UnsupportedSymbolException(Symbol pSymbol, Cursor pCursor)
            : base(string.Format("Symbol {0} is not supported", ((ParserSymbol)pSymbol.TableIndex())), pCursor)
        {
        }
    }
}