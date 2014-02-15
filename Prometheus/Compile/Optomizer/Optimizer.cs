using System.Collections.Generic;
using System.Linq;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Parser.Executors;

namespace Prometheus.Compile.Optomizer
{
    /// <summary>
    /// Optimizes a compiled node tree. This code is constantly modified to as grammar rules are changed in the parser, but the
    /// general idea for optimizing is two things. First, to reduce the number of nodes in the tree. Second, to change nodes
    /// to make work for the parser easier.
    /// </summary>
    public class Optimizer
    {
        /// <summary>
        /// Collapses collection symbols to a single array
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _arrays = new HashSet<GrammarSymbol>
                                                                 {
                                                                     GrammarSymbol.Statements,
                                                                     GrammarSymbol.ObjectDecls,
                                                                     GrammarSymbol.Program,
                                                                     GrammarSymbol.Parameters,
                                                                     GrammarSymbol.Arguments,
                                                                     GrammarSymbol.ArrayLiteralList,
                                                                     GrammarSymbol.ParameterList,
                                                                     GrammarSymbol.ArgumentList,
                                                                     GrammarSymbol.QualifiedList
                                                                 };

        /// <summary>
        /// These nodes can be dropped from the tree, if they have no child and no data.
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _drop = new HashSet<GrammarSymbol>
                                                               {
                                                                   GrammarSymbol.End,
                                                                   //GrammarSymbol.Block,
                                                                   GrammarSymbol.Statement,
                                                                   GrammarSymbol.Statements,
                                                                   GrammarSymbol.ObjectDecls,
                                                                   GrammarSymbol.BaseClassID,
                                                                   GrammarSymbol.MemberList
                                                               };

        /// <summary>
        /// These nodes can have their child promoted, if it's only one child.
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _promote = new HashSet<GrammarSymbol>
                                                                  {
                                                                      GrammarSymbol.Block,
                                                                      GrammarSymbol.Statements,
                                                                      GrammarSymbol.Statement,
                                                                      GrammarSymbol.ObjectDecls,
                                                                      GrammarSymbol.Value,
                                                                      GrammarSymbol.Arguments,
                                                                      GrammarSymbol.QualifiedList
                                                                  };

        /// <summary>
        /// These nodes have a child QualifiedID node's data assigned to them.
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _qualifiedData = new HashSet<GrammarSymbol>
                                                                        {
                                                                            GrammarSymbol.Assignment,
                                                                            GrammarSymbol.ObjectDecl,
                                                                            GrammarSymbol.PostIncOperator,
                                                                            GrammarSymbol.PreIncOperator,
                                                                            GrammarSymbol.PostDecOperator,
                                                                            GrammarSymbol.PreDecOperator
                                                                        };

        /// <summary>
        /// These nodes have their data moved to their parents.
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _shiftData = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.BaseClassID,
                                                                        GrammarSymbol.MemberList
                                                                    };

        /// <summary>
        /// Used to perform optimization
        /// </summary>
        private Executor _executor;

        /// <summary>
        /// The identifiers of objects that are implemented internally.
        /// </summary>
        private HashSet<string> _internalIds;

        /// <summary>
        /// Was the node tree modified
        /// </summary>
        private bool _modified;

        /// <summary>
        /// Converts the child nodes into a data reference to a qualifier ID.
        /// </summary>
        /// <param name="pNode"></param>
        public void Qualify(Node pNode)
        {
            for (int i = 0, c = pNode.Children.Count; i < c; i++)
            {
                Node child = pNode.Children[i];
                if (child.Type == GrammarSymbol.QualifiedList)
                {
                    pNode.Children.AddRange(child.Children);
                    pNode.Children[i] = null;
                    _modified = true;
                }
            }
            pNode.Reduce();
        }

        /// <summary>
        /// Moves the data from the child to the parent.
        /// </summary>
        /// <param name="pParent">The parent node</param>
        /// <param name="pChild">The child node</param>
        public static void ShiftData(Node pParent, Node pChild)
        {
/*
            for (int i = 0, c = pChild.Data.Count; i < c; i++)
            {
                // this reverses the order so that the data is is the same order
                // as the original parameters in the source code
                pParent.Data.Insert(0, pChild.Data[i]);
            }
*/
            pParent.Data.AddRange(pChild.Data);
            pChild.Data.Clear();
        }

        /// <summary>
        /// Replaces a call to a user function with a call to an internal function.
        /// </summary>
        /// <param name="pNode">The node to inspect</param>
        /// <returns>The node</returns>
        public Node CallInternal(Node pNode)
        {
            if (pNode.Children.Count == 0
                || pNode.Children[0].Type == GrammarSymbol.QualifiedID)
            {
                return pNode;
            }

            IdentifierType id = (IdentifierType)pNode.Children[0].Data[0];
            if (!_internalIds.Contains(id.Name))
            {
                return pNode;
            }

            DataType identifier = pNode.Children[0].Data[0];

            Node callInternal = new Node(GrammarSymbol.CallInternal, pNode.Location);
            callInternal.Data.Add(identifier);
            callInternal.Children.AddRange(pNode.Children.Skip(1));

            return callInternal;
        }

        /// <summary>
        /// Performs optimization of a node tree.
        /// </summary>
        /// <param name="pRoot">The root node</param>
        /// <returns>A node to used as the new root node.</returns>
        public Node Optimize(Node pRoot)
        {
            using (_executor = new Executor())
            {
                _internalIds = new HashSet<string>(_executor.GetInternalIds());

                do
                {
                    _modified = false;
                    pRoot = WalkBranch(pRoot);
                } while (_modified);

                return pRoot;
            }
        }

        /// <summary>
        /// Performs optimization of a single node.
        /// </summary>
        /// <param name="pNode">The node to optimize</param>
        /// <returns>Same node, a new node or null.</returns>
        public Node OptimizeNode(Node pNode)
        {
            // change MemberID nodes to ValidID nodes (so Identifier is one type only).
            if (pNode.Type == GrammarSymbol.MemberID)
            {
                Node valid = new Node(GrammarSymbol.ValidID, pNode.Location);
                valid.Data.AddRange(pNode.Data);
                valid.Children.AddRange(pNode.Children);
                return valid;
            }

            // promote a single child up the tree if the current node does no work
            if (_promote.Contains(pNode.Type)
                && pNode.Children.Count == 1
                && pNode.Data.Count == 0)
            {
                return pNode.Children[0];
            }

            // drop an empty node
            if ((_drop.Contains(pNode.Type) || _arrays.Contains(pNode.Type))
                && pNode.Children.Count == 0
                && pNode.Data.Count == 0)
            {
                return null;
            }

            // bring up children from inner array nodes
            if (_arrays.Contains(pNode.Type))
            {
                List<Node> newChildren = new List<Node>();
                for (int i = 0, c = pNode.Children.Count; i < c; i++)
                {
                    if (_arrays.Contains(pNode.Children[i].Type))
                    {
                        newChildren.AddRange(pNode.Children[i].Children);
                        pNode.Children[i].Children.Clear();
                        _modified = true;
                    }
                    else
                    {
                        newChildren.Add(pNode.Children[i]);
                    }
                }
                pNode.Children.Clear();
                pNode.Children.AddRange(newChildren);
            }

            // bring up children of a certain type
            if (pNode.Type == GrammarSymbol.ArrayLiteral
                && pNode.Children.Count == 1
                && pNode.Children[0].Type == GrammarSymbol.ArrayLiteralList)
            {
                List<Node> children = pNode.Children[0].Children;
                pNode.Children.Clear();
                pNode.Children.AddRange(children);
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
        public Node WalkBranch(Node pNode)
        {
            if (pNode.Type == GrammarSymbol.QualifiedID
                && pNode.Children.Count != 0)
            {
                Qualify(pNode);
            }

            if (pNode.Type == GrammarSymbol.ObjectDecl
                && !pNode.HasChild(GrammarSymbol.ObjectConstructor))
            {
                Node block = pNode.FindChild(GrammarSymbol.Block);
                pNode.Children.Remove(block);
                pNode.Children.Add(new Node(GrammarSymbol.ObjectConstructor, block.Location, new[]{block}));
            }

            if (_qualifiedData.Contains(pNode.Type)
                && pNode.Children.Count >= 1
                && pNode.Children[0].Type == GrammarSymbol.QualifiedID
                && pNode.Children[0].Children.Count == 0)
            {
                Assertion.Data(1, pNode.Children[0]);
                QualifiedType qualifiedOldType = Assertion.Get<QualifiedType>(pNode.Children[0], 0);
                pNode.Data.Insert(0, qualifiedOldType);
                pNode.Children.RemoveAt(0);
            }

            for (int i = 0, c = pNode.Children.Count; i < c; i++)
            {
                Node child = pNode.Children[i];

                if (_shiftData.Contains(child.Type))
                {
                    pNode.Data.AddRange(child.Data);
                    pNode.Data.Clear();
                }

                pNode.Children[i] = WalkBranch(child);
                _modified |= pNode.Children[i] != child;
            }

            pNode.Reduce();

            return OptimizeNode(pNode);
        }
    }
}