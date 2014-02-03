using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Parser;
using Prometheus.Runtime;

namespace Prometheus.Compile.Optomizer
{
    /// <summary>
    /// Optimizes a compiled node tree.
    /// </summary>
    public class Optimizer
    {
        /// <summary>
        /// These symbols can be dropped from the tree, if they have no child and no data.
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _drop = new HashSet<GrammarSymbol>
                                                               {
                                                                   GrammarSymbol.Block,
                                                                   GrammarSymbol.Statement,
                                                                   GrammarSymbol.Statements,
                                                               };

        /// <summary>
        /// These symbols can have their child promoted, if it's only one child.
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _promote = new HashSet<GrammarSymbol>
                                                                  {
                                                                      GrammarSymbol.Statements,
                                                                      GrammarSymbol.Statement,
                                                                      GrammarSymbol.Value
                                                                  };

        /// <summary>
        /// The current position while walking the tree
        /// </summary>
        private Cursor _cursor;

        /// <summary>
        /// Was the node tree modified
        /// </summary>
        private bool _modified;

        /// <summary>
        /// A list of optimizers
        /// </summary>
        private List<iNodeOptimizer> _nodeOptimizers;

        /// <summary>
        /// Performs optimization of a single node.
        /// </summary>
        /// <param name="pNode">The node to optimize</param>
        /// <returns>Same node, a new node or null.</returns>
        private Node OptimizeNode(Node pNode)
        {
            // promote a single child up the tree if the current node does no work
            if (_promote.Contains(pNode.Type) &&
                pNode.Children.Count == 1 &&
                pNode.Data.Count == 0)
            {
                return pNode.Children[0];
            }

            // drop an empty statement
            if (_drop.Contains(pNode.Type) &&
                pNode.Children.Count == 0 &&
                pNode.Data.Count == 0)
            {
                return null;
            }

            // TODO: I think this can be improved. 
            // TODO: <Statements> should not have a <Statement> or <Statements> as children. 
            // TODO: Those children can be moved up as long as operations continue to run in the correct order.

            // statements that contain 2 child, and one is another statements node
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
            _cursor.Node = pNode;
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
        /// Performs optimization of a node tree.
        /// </summary>
        /// <param name="pRoot">The root node</param>
        /// <returns>A node to used as the new root node.</returns>
        public Node Optimize(Node pRoot)
        {
            _cursor = new Cursor(pRoot);

            _nodeOptimizers = new List<iNodeOptimizer>
                              {
                                  new MathOperators(_cursor),
                                  new RelationalOperators(_cursor)
                              };

            do
            {
                _modified = false;
                pRoot = WalkBranch(pRoot);
            } while (_modified);

            return pRoot;
        }
    }
}