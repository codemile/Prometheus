using System.Collections.Generic;
using Prometheus.Exceptions.Compiler;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Parser;
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
                                                                     GrammarSymbol.TestDecls,
                                                                     GrammarSymbol.ImportDecls,
                                                                     GrammarSymbol.Program,
                                                                     GrammarSymbol.ArgumentArray,
                                                                     GrammarSymbol.ArrayLiteralList,
                                                                     GrammarSymbol.ParameterList,
                                                                     GrammarSymbol.ArgumentList,
                                                                     GrammarSymbol.QualifiedList
                                                                 };

        /// <summary>
        /// Declaration types that contain an executable block of code (like a function or object constructor). The block
        /// of code is parented to a new node of the value type. This allows that block of code to be stored, and not executed
        /// by the parser until the declaration is used.
        /// </summary>
        private static readonly Dictionary<GrammarSymbol, GrammarSymbol> _declarations =
            new Dictionary
                <GrammarSymbol, GrammarSymbol>
            {
                {GrammarSymbol.ObjectDecl, GrammarSymbol.ObjectBlock},
                {GrammarSymbol.FunctionDecl, GrammarSymbol.FunctionBlock},
                {GrammarSymbol.TestDecl, GrammarSymbol.TestBlock}
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
                                                                   GrammarSymbol.TestDecls,
                                                                   GrammarSymbol.ImportDecls,
                                                                   GrammarSymbol.BaseClassID
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
                                                                      GrammarSymbol.TestDecls,
                                                                      GrammarSymbol.ImportDecls,
                                                                      GrammarSymbol.Value,
                                                                      GrammarSymbol.QualifiedList,
                                                                      GrammarSymbol.ClassNameList
                                                                  };

        /// <summary>
        /// These nodes are removed but their children are kept and inserted into the same position as the removed node.
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _remove = new HashSet<GrammarSymbol>
                                                                 {
                                                                     GrammarSymbol.ProgramTest,
                                                                     GrammarSymbol.ProgramCode,
                                                                     GrammarSymbol.BaseClassID,
                                                                     GrammarSymbol.ClassNameList
                                                                 };

        /// <summary>
        /// These nodes have their data moved to their parents.
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _shiftData = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.BaseClassID
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
        /// Performs optimization of a node tree.
        /// </summary>
        /// <param name="pRoot">The root node</param>
        /// <returns>A node to used as the new root node.</returns>
        public Node Optimize(Node pRoot)
        {
            using (_executor = new Executor(new Cursor()))
            {
                _internalIds = new HashSet<string>(_executor.GetInternalIds());

                do
                {
                    _modified = false;
                    pRoot = WalkBranch(pRoot) ?? new Node(GrammarSymbol.Statements, Location.None);
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
            if (pNode.Type == GrammarSymbol.Generic0Args
                || pNode.Type == GrammarSymbol.Generic1Args
                || pNode.Type == GrammarSymbol.GenericNArgs)
            {
                string name = pNode.FirstData().Cast<IdentifierType>().Name;
                if (!_internalIds.Contains(name))
                {
                    throw new LexicalException(string.Format("Command not supported <{0}>", name),pNode.Location);
                }
            }

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

            return _executor.Optimize(pNode);
        }

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

            foreach (GrammarSymbol promote in _remove)
            {
                Node remove = pNode.FindChild(promote);
                if (remove == null)
                {
                    continue;
                }
                pNode.Children.InsertRange(pNode.Children.IndexOf(remove), remove.Children);
                pNode.Children.Remove(remove);
                _modified = true;
            }

            if (_declarations.ContainsKey(pNode.Type)
                && !pNode.HasChild(_declarations[pNode.Type]))
            {
                Node block = pNode.FindChild(GrammarSymbol.Block);
                pNode.Children.Remove(block);
                pNode.Children.Add(new Node(_declarations[pNode.Type], block.Location, new[] {block}));
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