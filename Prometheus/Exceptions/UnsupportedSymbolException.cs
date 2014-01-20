using GOLD;
using Markdown.Documents;

namespace Prometheus.Exceptions
{
    public class UnsupportedSymbolException : ParserException
    {
        /// <summary>
        /// Throw a message.
        /// </summary>
        public UnsupportedSymbolException(ParserSymbol pSymbol, DocumentCursor pCursor)
            : base(string.Format("Symbol {0} is not supported", pSymbol), pCursor)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public UnsupportedSymbolException(Symbol pSymbol, DocumentCursor pCursor)
            : base(string.Format("Symbol {0} is not supported", ((ParserSymbol)pSymbol.TableIndex())), pCursor)
        {
        }
    }
}