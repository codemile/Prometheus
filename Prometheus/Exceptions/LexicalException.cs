using Markdown.Documents;

namespace Prometheus.Exceptions
{
    internal class LexicalException : ParserException
    {
        /// <summary>
        /// Constructor by parser.
        /// </summary>
        public LexicalException(GOLD.Parser pParser, DocumentCursor pCursor)
            : base(string.Format("Unexpected character {0} found", pParser.CurrentToken().Data), pCursor)
        {
        }

        /// <summary>
        /// Constructor by parser.
        /// </summary>
        public LexicalException(string pMessage, DocumentCursor pCursor)
            : base(pMessage, pCursor)
        {
        }
    }
}