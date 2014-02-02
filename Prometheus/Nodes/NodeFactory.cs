using System.Collections.Generic;
using GOLD;
using Prometheus.Compile;
using Prometheus.Grammar;

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
        private readonly List<GrammarSymbol> _dataTypes;

        /// <summary>
        /// Gets the grammar symbol.
        /// </summary>
        /// <param name="pReduction">The node being reduced.</param>
        /// <returns>The symbol</returns>
        private static GrammarSymbol getSymbol(Reduction pReduction)
        {
            Production parent = pReduction.Parent;
            Symbol symbol = parent.Head();
            GrammarSymbol parserSymbol = (GrammarSymbol)symbol.TableIndex();
            return parserSymbol;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public NodeFactory()
        {
            _dataTypes = new List<GrammarSymbol>();
        }

        /// <summary>
        /// </summary>
        /// <param name="pReduction"></param>
        /// <param name="pLocation"></param>
        /// <returns></returns>
        public Node Create(Reduction pReduction, Location pLocation)
        {
            GrammarSymbol symbol = getSymbol(pReduction);

            Node node = new Node(symbol, pLocation);
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
                GrammarSymbol dataType = (GrammarSymbol)parent.TableIndex();
                if (!_dataTypes.Contains(dataType))
                {
                    continue;
                }

                string str = (string)token.Data;
                node.Data.Add(DataFactory.Create(pLocation, dataType, str));
            }
            return node;
        }

        /// <summary>
        /// Adds a symbol to the list of allowed type
        /// to be attached to nodes as data.
        /// </summary>
        /// <param name="pParserSymbol">The symbol that defines a data type.</param>
        public void DataType(GrammarSymbol pParserSymbol)
        {
            _dataTypes.Add(pParserSymbol);
        }
    }
}