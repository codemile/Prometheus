using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Parser.Executors;

namespace Prometheus.Compile.Optimizers
{
    /// <summary>
    /// Prepares qualifier ID references.
    /// </summary>
    public class OptimizeQualifier : BaseOptimizer
    {
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.MemberID,
                                                                        GrammarSymbol.QualifiedID
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public OptimizeQualifier(iExecutor pExecutor) 
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
            if (pNode.Type == GrammarSymbol.MemberID)
            {
                pNode.Type = GrammarSymbol.ValidID;
                return true;
            }

            if (pNode.Type != GrammarSymbol.QualifiedID 
                || pNode.Children.Count == 0)
            {
                return false;
            }

            bool modified = false;
            for (int i = 0, c = pNode.Children.Count; i < c; i++)
            {
                Node child = pNode.Children[i];
                if (child.Type != GrammarSymbol.QualifiedList)
                {
                    continue;
                }
                pNode.Children.AddRange(child.Children);
                pNode.Children[i] = null;
                modified = true;
            }
            if (modified)
            {
                pNode.Reduce();
            }

            return modified;
        }
    }
}