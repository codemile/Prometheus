using System.Collections.Generic;
using GOLD;
using Prometheus.Compile;
using Prometheus.Parser;

namespace Prometheus.Nodes
{
    /// <summary>
    /// Handles converting the upside down tree of data from
    /// the parser into a top down tree of nodes that this
    /// library can run as commands.
    /// </summary>
    public class NodeFactory
    {
        /// <summary>
        /// A list of symbols that can be attached to
        /// nodes as data.
        /// </summary>
        private readonly List<ParserSymbol> _dataTypes;

        /// <summary>
        /// Gets the grammar symbol.
        /// </summary>
        /// <param name="pReduction">The node being reduced.</param>
        /// <returns>The symbol</returns>
        private static ParserSymbol getSymbol(Reduction pReduction)
        {
            Production parent = pReduction.Parent;
            Symbol symbol = parent.Head();
            ParserSymbol parserSymbol = (ParserSymbol)symbol.TableIndex();
            return parserSymbol;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public NodeFactory()
        {
            _dataTypes = new List<ParserSymbol>();
        }

        /// <summary>
        /// </summary>
        /// <param name="pReduction"></param>
        /// <param name="pCursor"></param>
        /// <returns></returns>
        public Node Create(Reduction pReduction, Cursor pCursor)
        {
            ParserSymbol symbol = getSymbol(pReduction);

            Node node = new Node(symbol,0,pCursor.Row, pCursor.Column);
            for (int i = 0; i < pReduction.Count(); i++)
            {
                Token token = pReduction[i];
                Node child = pReduction[i].Data as Node;
                if (child != null)
                {
                    node.Children.Add(child);
                    continue;
                }

                SymbolType t = token.Type();
                if (t != SymbolType.Content)
                {
                    continue;
                }

                Symbol parent = token.Parent;
                ParserSymbol dataType = (ParserSymbol)parent.TableIndex();
                if (!_dataTypes.Contains(dataType))
                {
                    continue;
                }

                string str = (string)token.Data;
                node.Data.Add(new Data(dataType, str));
            }
            return node;
        }

        /// <summary>
        /// Adds a symbol to the list of allowed type
        /// to be attached to nodes as data.
        /// </summary>
        /// <param name="pParserSymbol">The symbol that defines a data type.</param>
        public void DataType(ParserSymbol pParserSymbol)
        {
            _dataTypes.Add(pParserSymbol);
        }
    }
}