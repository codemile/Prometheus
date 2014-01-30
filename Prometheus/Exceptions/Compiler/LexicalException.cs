using Prometheus.Compile;

namespace Prometheus.Exceptions.Compiler
{
    internal class LexicalException : CompilerException
    {
        /// <summary>
        /// Constructor by parser.
        /// </summary>
        public LexicalException(GOLD.Parser pParser, Cursor pCursor)
            : base(string.Format("Unexpected character {0} found", pParser.CurrentToken().Data), pCursor)
        {
        }

        /// <summary>
        /// Constructor by parser.
        /// </summary>
        public LexicalException(string pMessage, Cursor pCursor)
            : base(pMessage, pCursor)
        {
        }
    }
}