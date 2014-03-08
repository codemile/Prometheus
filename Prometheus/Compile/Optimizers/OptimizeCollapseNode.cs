using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Parser.Executors;

namespace Prometheus.Compile.Optimizers
{
    /// <summary>
    /// Removes nodes from the tree that are only being used to contain 1 child.
    /// </summary>
    public class OptimizeCollapseNode : BaseOptimizer
    {
        /// <summary>
        /// These nodes can have their child promoted, if it's only one child.
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.Statements,
                                                                        GrammarSymbol.Statement,
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public OptimizeCollapseNode(iExecutor pExecutor)
            : base(pExecutor, _nodeTypes)
        {
        }

        /// <summary>
        /// The parent node will become the child node if it has only one child.
        /// </summary>
        public override bool OptimizeParent(Node pParent, Node pChild)
        {
            if (pParent.Data.Count != 0
                || pParent.Children.Count != 1)
            {
                return false;
            }
            pParent.Set(pChild);
            return true;
        }
    }
}