using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLD;
using Prometheus.Compile;

namespace Prometheus.Exceptions.Compiler
{
    /// <summary>
    /// </summary>
    public class SyntaxException : CompilerException
    {
        /// <summary>
        /// Formats the syntax error message.
        /// </summary>
        private static string Message(GOLD.Parser pParser, Cursor pCursor)
        {
            string found = pParser.CurrentToken() != null ? pParser.CurrentToken().Data.ToString() : "null";

            SymbolList symbolList = pParser.ExpectedSymbols();
            if (symbolList == null)
            {
                return string.Format("Syntax error: Unexpected token {0} ", found);
            }

            List<string> message = new List<string>();

            List<string> expecting = new List<string>();
            IEnumerable<SymbolType> types = CollectTypes(symbolList).Distinct();
            foreach (SymbolType type in types)
            {
                switch (type)
                {
                    case SymbolType.Nonterminal:
                        expecting.Add("value");
                        break;
                    case SymbolType.Noise:
                        expecting.Add("whitespace");
                        break;
                    case SymbolType.GroupStart:
                        expecting.Add("start of group");
                        break;
                    case SymbolType.GroupEnd:
                        expecting.Add("end of group");
                        break;
                    case SymbolType.Error:
                        // TODO: Can this type be a syntax error?
                        expecting.Add("error");
                        break;
                    case SymbolType.End:
                        expecting.Add("end of file");
                        break;
                    case SymbolType.Content:
                        expecting.Add("statement");
                        break;
                }
            }

            message.Add(string.Format("Syntax error: Was expecting {0} but found '{1}' instead {2}",
                string.Join(", or ", expecting), found, pCursor));
            message.Add("");
            message.Add(pCursor.Line);
            message.Add("^".PadLeft(pCursor.Column));

            return string.Join(Environment.NewLine, message);
        }

        /// <summary>
        /// Converts a symbol list into a collection.
        /// </summary>
        /// <param name="pSymbols">The symbols</param>
        /// <returns>The new collection</returns>
        private static IEnumerable<SymbolType> CollectTypes(SymbolList pSymbols)
        {
            for (int i = 0, c = pSymbols.Count(); i < c; i++)
            {
                yield return pSymbols[i].Type;
            }
        }

        /// <summary>
        /// Constructor by parser.
        /// </summary>
        /// <param name="pParser"></param>
        /// <param name="pCursor"></param>
        public SyntaxException(GOLD.Parser pParser, Cursor pCursor)
            : base(Message(pParser, pCursor))
        {
        }
    }
}