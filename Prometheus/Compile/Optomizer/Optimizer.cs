using System.Collections.Generic;
using System.Linq;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Parser.Executors;

namespace Prometheus.Compile.Optomizer
{
    /// <summary>
    /// Optimizes a compiled node tree.
    /// </summary>
    public class Optimizer
    {
        /// <summary>
        /// These nodes can be dropped from the tree, if they have no child and no data.
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _drop = new HashSet<GrammarSymbol>
                                                               {
                                                                   GrammarSymbol.End,
                                                                   GrammarSymbol.Block,
                                                                   GrammarSymbol.Statement,
                                                                   GrammarSymbol.Statements,
                                                                   GrammarSymbol.FormalParameterList,
                                                                   GrammarSymbol.Arguments,
                                                                   GrammarSymbol.BaseClass
                                                               };

        /// <summary>
        /// These nodes can have their child promoted, if it's only one child.
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _promote = new HashSet<GrammarSymbol>
                                                                  {
                                                                      GrammarSymbol.Block,
                                                                      GrammarSymbol.Statements,
                                                                      GrammarSymbol.Statement,
                                                                      GrammarSymbol.Value,
                                                                      GrammarSymbol.Arguments
                                                                  };

        /// <summary>
        /// These nodes have their data moved to their parents.
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _shiftData = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.FormalParameterList,
                                                                        GrammarSymbol.BaseClass
                                                                    };

        /// <summary>
        /// Used to perform optimization
        /// </summary>
        private Executor _executor;

        private HashSet<string> _internalIds;

        /// <summary>
        /// Was the node tree modified
        /// </summary>
        private bool _modified;

        /// <summary>
        /// Moves the data from the child to the parent.
        /// </summary>
        /// <param name="pParent">The parent node</param>
        /// <param name="pChild">The child node</param>
        private static void ShiftData(Node pParent, Node pChild)
        {
            for (int i = 0, c = pChild.Data.Count; i < c; i++)
            {
                // this reverses the order so that the data is is the same order
                // as the original parameters in the source code
                pParent.Data.Insert(0, pChild.Data[i]);
            }
            pChild.Data.Clear();
        }

        /// <summary>
        /// Replaces a call to a user function with a call to an internal function.
        /// </summary>
        /// <param name="pNode">The node to inspect</param>
        /// <returns>The node</returns>
        private Node CallInternal(Node pNode)
        {
            if (pNode.Children.Count == 0 ||
                pNode.Children[0].Type != GrammarSymbol.Variable)
            {
                return pNode;
            }

            Data id = pNode.Children[0].Data[0];
            if (!_internalIds.Contains(id.getIdentifier().Name))
            {
                return pNode;
            }

            Data identifier = pNode.Children[0].Data[0];

            Node callInternal = new Node(GrammarSymbol.CallInternal, pNode.Location);
            callInternal.Data.Add(identifier);
            callInternal.Children.AddRange(pNode.Children.Skip(1));

            return callInternal;
        }

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

            // check if a function call is to an internal method
            if (pNode.Type == GrammarSymbol.CallExpression)
            {
                pNode = CallInternal(pNode);
            }

            return _executor.Optimize(pNode);
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

                if (_shiftData.Contains(child.Type))
                {
                    ShiftData(pNode, child);
                }

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
            _executor = new Executor();
            _internalIds = new HashSet<string>(_executor.GetInternalIds());

            do
            {
                _modified = false;
                pRoot = WalkBranch(pRoot);
            } while (_modified);

            return pRoot;
        }
    }
}