using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Parser.Executors.Handlers
{
    /// <summary>
    /// Handles generic blocks of code where the child should be executed in order.
    /// </summary>
    public class HandleBlocks : ExecutorHandler
    {
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.Program,
                                                                        GrammarSymbol.Block,
                                                                        GrammarSymbol.Statements
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public HandleBlocks(iExecutor pExecutor)
            : base(pExecutor, _nodeTypes)
        {
        }

        /// <summary>
        /// Handle execution of a node.
        /// </summary>
        public override DataType Handle(Node pNode)
        {
            ExecuteChildren(pNode);
            return UndefinedType.Undefined;
        }
    }
}