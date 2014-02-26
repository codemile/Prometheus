using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Parser.Executors;

namespace Prometheus.Compile.Optimizers
{
    /// <summary>
    /// </summary>
    public class OptimizeTest : BaseOptimizer
    {
        /// <summary>
        /// These nodes can have their child promoted, if it's only one child.
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.TestDecl
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public OptimizeTest(iExecutor pExecutor)
            : base(pExecutor, _nodeTypes)
        {
        }

        /// <summary>
        /// Called for each node in the tree. Implement this to
        /// modify just the node.
        /// </summary>
        /// <returns>True if tree was modified.</returns>
        public override bool OptimizeNode(Node pNode)
        {
            if (pNode.Children.Count != 2)
            {
                return false;
            }

            IdentifierType testName = pNode.Children[0].FirstData().Cast<IdentifierType>();
            pNode.Data.Add(testName);
            pNode.Children.RemoveAt(0);

            return true;
        }
    }
}