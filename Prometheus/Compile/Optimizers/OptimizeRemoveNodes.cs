using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Parser.Executors;

namespace Prometheus.Compile.Optimizers
{
    /// <summary>
    /// Always remove these nodes from the tree, but keep their children.
    /// </summary>
    public class OptimizeRemoveNodes : BaseOptimizer
    {
        /// <summary>
        /// These nodes can have their child promoted, if it's only one child.
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.ObjectDecls,
                                                                        GrammarSymbol.TestDecls,
                                                                        GrammarSymbol.ImportDecls,
                                                                        GrammarSymbol.ProgramTest,
                                                                        GrammarSymbol.ProgramCode,
                                                                        GrammarSymbol.BaseClassID,
                                                                        GrammarSymbol.QualifiedList,
                                                                        GrammarSymbol.ClassNameList,
                                                                        GrammarSymbol.ClassNameList,
                                                                        GrammarSymbol.ParameterList
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public OptimizeRemoveNodes(iExecutor pExecutor)
            : base(pExecutor, _nodeTypes)
        {
        }

        /// <summary>
        /// Removes the node from the tree, but keeps the children.
        /// </summary>
        public override bool OptimizeChild(Node pParent, Node pChild)
        {
            pParent.Children.ReplaceNode(pChild, pChild.Children);
            return true;
        }
    }
}