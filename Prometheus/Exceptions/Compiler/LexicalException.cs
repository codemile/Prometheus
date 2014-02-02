using Prometheus.Compile;

namespace Prometheus.Exceptions.Compiler
{
    internal class LexicalException : CompilerException
    {
        /// <summary>
        /// Constructor by parser.
        /// </summary>
        public LexicalException(GOLD.Parser pParser, Location pLocation)
            : base(string.Format("Unexpected character {0} found", pParser.CurrentToken().Data), pLocation)
        {
        }

        /// <summary>
        /// Constructor by parser.
        /// </summary>
        public LexicalException(string pMessage, Location pLocation)
            : base(pMessage, pLocation)
        {
        }
    }
}