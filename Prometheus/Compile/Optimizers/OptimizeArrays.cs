using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Parser.Executors;

namespace Prometheus.Compile.Optimizers
{
    /// <summary>
    /// Lists in the grammar are created as a chain of nodes. This optimizer rearranges the chain
    /// so that the nodes are all children of a single parent.
    /// </summary>
    public class OptimizeArrays : BaseOptimizer
    {
        /// <summary>
        /// Collapses collection symbols to a single array
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.ArrayLiteral,
                                                                        GrammarSymbol.ArrayLiteralList
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public OptimizeArrays(iExecutor pExecutor)
            : base(pExecutor, _nodeTypes)
        {
        }

        /// <summary>
        /// Create a single ArrayLiteral
        /// </summary>
        public override bool OptimizeParent(Node pParent, Node pChild)
        {
            if (pChild.Symbol != GrammarSymbol.ArrayLiteralList)
            {
                return false;
            }
            pParent.Children.ReplaceNode(pChild, pChild.Children);
            return true;
        }
    }
}