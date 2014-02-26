using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Parser.Executors;

namespace Prometheus.Compile.Optimizers
{
    /// <summary>
    /// Drops empty nodes from the tree.
    /// </summary>
    public class OptimizeEmptyNode : BaseOptimizer
    {
        /// <summary>
        /// These nodes can be dropped from the tree, if they have no child and no data.
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.End,
                                                                        GrammarSymbol.Statement,
                                                                        GrammarSymbol.Statements,
                                                                        GrammarSymbol.Program,
                                                                        GrammarSymbol.ProgramCode,
                                                                        GrammarSymbol.ImportDecls,
                                                                        GrammarSymbol.ObjectDecls
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public OptimizeEmptyNode(iExecutor pExecutor)
            : base(pExecutor, _nodeTypes)
        {
        }

        /// <summary>
        /// Remove a child from the parent if that child is empty.
        /// </summary>
        public override bool OptimizeChild(Node pParent, Node pChild)
        {
            if (!pChild.IsEmpty())
            {
                return false;
            }

            pParent.Children.Remove(pChild);

            return true;
        }
    }
}