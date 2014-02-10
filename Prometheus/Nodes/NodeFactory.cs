using GOLD;
using Prometheus.Compile;
using Prometheus.Grammar;
using Prometheus.Nodes.Types;

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
        /// Initializes a new Node object from a Reduction object.
        /// </summary>
        /// <param name="pReduction">The reduction object.</param>
        /// <param name="pLocation">The location in the code.</param>
        /// <returns>The new node</returns>
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
                if (!DataTypeFactory.isDataType(dataType))
                {
                    continue;
                }

                string str = (string)token.Data;
                node.Data.Add(DataTypeFactory.Create(pLocation, dataType, str));
            }
            return node;
        }
    }
}