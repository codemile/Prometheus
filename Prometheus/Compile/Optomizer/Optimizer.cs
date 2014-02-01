using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Runtime;
using Prometheus.Tokens.Statements;

namespace Prometheus.Compile.Optomizer
{
    /// <summary>
    /// Optimizes a compiled node tree.
    /// </summary>
    public class Optimizer
    {
        private readonly List<iNodeOptimizer> _nodeOptimizers;

        /// <summary>
        /// Was the node tree modified
        /// </summary>
        private bool _modified;

        /// <summary>
        /// Performs optimization of a single node.
        /// </summary>
        /// <param name="pNode">The node to optimize</param>
        /// <returns>Same node, a new node or null.</returns>
        private Node OptimizeNode(Node pNode)
        {
            // promote a single child up the tree if the current node does no work
            if ((pNode.Type == GrammarSymbol.Statements ||
                 pNode.Type == GrammarSymbol.Statement || 
                 pNode.Type == GrammarSymbol.Value
                 ) && pNode.Children.Count == 1 &&
                pNode.Data.Count == 0)
            {
                return pNode.Children[0];
            }

            // drop an empty statement
            if (pNode.Type == GrammarSymbol.Statement &&
                pNode.Children.Count == 0 &&
                pNode.Data.Count == 0)
            {
                return null;
            }

            // statements that contains 2 child, and one is another statements node
            // can be merged into just 1 statements
            if (pNode.Type == GrammarSymbol.Statements &&
                pNode.Children.Count == 2 &&
                pNode.Data.Count == 0)
            {
                if (pNode.Children[0].Type == GrammarSymbol.Statements &&
                    pNode.Children[1].Type != GrammarSymbol.Statements)
                {
                    pNode.Children[0].Children.Add(pNode.Children[1]);
                    return pNode.Children[0];
                }
            }

            // run optimizers on the node
            foreach (iNodeOptimizer nodeOp in _nodeOptimizers)
            {
                pNode = nodeOp.Optomize(pNode);
                if (pNode == null)
                {
                    break;
                }
            }

            return pNode;
        }

        /// <summary>
        /// Process all the nodes in the tree by walking all branches. Update any
        /// children that are modified, or remove children if a recursive call
        /// returns null for that child.
        /// </summary>
        /// <param name="pNode">The node to walk</param>
        /// <returns>The same node, a new node or null.</returns>
        private Node WalkBranch(Node pNode)
        {
            for (int i = 0, c = pNode.Children.Count; i < c; i++)
            {
                Node child = pNode.Children[i];
                pNode.Children[i] = WalkBranch(child);

                _modified |= pNode.Children[i] != child;
            }

            pNode.Reduce();

            return OptimizeNode(pNode);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Optimizer()
        {
            _nodeOptimizers = new List<iNodeOptimizer>
                              {
                                  new MathOperators(),
                                  new RelationalOperators()
                              };
        }

        /// <summary>
        /// Performs optimization of a node tree.
        /// </summary>
        /// <param name="pRoot">The root node</param>
        /// <returns>A node to used as the new root node.</returns>
        public Node Optimize(Node pRoot)
        {
            do
            {
                _modified = false;
                pRoot = WalkBranch(pRoot);
            } while (_modified);

            return pRoot;
        }
    }
}