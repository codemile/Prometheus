using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Parser.Executors;

namespace Prometheus.Compile.Optimizers
{
    /// <summary>
    /// Lists in the grammar are created as a chain of nodes. This optimizer rearranges the chain
    /// so that the nodes are all children of a single parent.
    /// </summary>
    public class OptimizeLists : BaseOptimizer
    {
        /// <summary>
        /// Collapses collection symbols to a single array
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.Statements,
                                                                        GrammarSymbol.ObjectDecls,
                                                                        GrammarSymbol.TestDecls,
                                                                        GrammarSymbol.ImportDecls,
                                                                        GrammarSymbol.Program,
                                                                        GrammarSymbol.ArgumentArray,
                                                                        GrammarSymbol.ParameterList,
                                                                        GrammarSymbol.ArgumentList,
                                                                        GrammarSymbol.QualifiedList
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public OptimizeLists(iExecutor pExecutor)
            : base(pExecutor, _nodeTypes)
        {
        }

        /// <summary>
        /// Moves the children nodes to the parent
        /// </summary>
        public override bool OptimizeNode(Node pNode)
        {
            bool modified = false;
            List<Node> newChildren = new List<Node>();
            for (int i = 0, c = pNode.Children.Count; i < c; i++)
            {
                Node child = pNode.Children[i];
                if (_nodeTypes.Contains(child.Type))
                {
                    newChildren.AddRange(child.Children);
                    child.Children.Clear();
                    modified = true;
                }
                else
                {
                    newChildren.Add(child);
                }
            }
            pNode.Children.Clear();
            pNode.Children.AddRange(newChildren);

            return modified;
        }
    }
}