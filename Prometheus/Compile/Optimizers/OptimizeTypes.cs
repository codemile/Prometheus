using System;
using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Parser.Executors;

namespace Prometheus.Compile.Optimizers
{
    /// <summary>
    /// Value nodes can have their data assigned to their parents, and then be dropped from the tree.
    /// </summary>
    public class OptimizeTypes : BaseOptimizer
    {
        /// <summary>
        /// These nodes can have their child promoted, if it's only one child.
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.Types
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public OptimizeTypes(iExecutor pExecutor)
            : base(pExecutor, _nodeTypes)
        {
        }

        /// <summary>
        /// Move the value node's data to the parent.
        /// </summary>
        public override bool OptimizeChild(Node pParent, Node pChild)
        {
#if DEBUG
            Assertion.Children(0, pChild);
            Assertion.Data(1, pChild);
#endif
            pParent.Data.Add(pChild.FirstData());
            pParent.Children.Remove(pChild);
            return true;
        }
    }
}