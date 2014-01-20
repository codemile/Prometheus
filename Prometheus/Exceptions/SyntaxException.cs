using System;
using System.Text;
using GOLD;
using Markdown.Documents;

namespace Prometheus.Exceptions
{
    public class SyntaxException : ParserException
    {
        /// <summary>
        /// Formats the syntax error message.
        /// </summary>
        private static string Message(GOLD.Parser pParser)
        {
            string found = pParser.CurrentToken() != null ? pParser.CurrentToken().Data.ToString() : "null";

            StringBuilder expecting = new StringBuilder();
            if (pParser.ExpectedSymbols() != null)
            {
                SymbolList symbolList = pParser.ExpectedSymbols();
                if (symbolList.Count() > 0)
                {
                    if (symbolList.Count() > 1)
                    {
                        expecting.Append("either ");
                    }
                    string[] symbols = new string[symbolList.Count()];
                    for (int i = 0, c = symbolList.Count(); i < c; i++)
                    {
                        Symbol symbol = symbolList[i];
                        symbols[i] = string.Format("'{0}'", symbol.Text());
                    }
                    expecting.Append(string.Join(", ", symbols));
                }
            }

            return string.Format("Syntax error: Was expecting {0} but found '{1}' instead", expecting, found);
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SyntaxException(DocumentCursor pCursor)
            : base(pCursor)
        {
        }

        /// <summary>
        /// Message constructor
        /// </summary>
        public SyntaxException(string pMessage, DocumentCursor pCursor)
            : base(pMessage, pCursor)
        {
        }

        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        public SyntaxException(string pMessage, DocumentCursor pCursor, Exception pInnerException)
            : base(pMessage, pCursor, pInnerException)
        {
        }

        /// <summary>
        /// Constructor by parser.
        /// </summary>
        /// <param name="pParser"></param>
        public SyntaxException(GOLD.Parser pParser, DocumentCursor pCursor)
            : base(Message(pParser), pCursor)
        {
        }
    }
}