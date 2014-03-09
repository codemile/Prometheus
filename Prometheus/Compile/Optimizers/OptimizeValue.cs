using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Parser.Executors;

namespace Prometheus.Compile.Optimizers
{
    /// <summary>
    /// Drops the parent node if the parent is Value. Value nodes should only hold constant data, and not have children.
    /// </summary>
    public class OptimizeValue : BaseOptimizer
    {
        /// <summary>
        /// These nodes can have their child promoted, if it's only one child.
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.Value
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public OptimizeValue(iExecutor pExecutor)
            : base(pExecutor, _nodeTypes)
        {
        }

        /// <summary>
        /// Move the value node's data to the parent.
        /// </summary>
        public override bool OptimizeChild(Node pParent, Node pChild)
        {
            if (pChild.Data.Count != 0
                || pChild.Children.Count != 1)
            {
                return false;
            }

            pParent.Children.ReplaceNode(pChild, pChild.Children);
            return true;
        }
    }
}