using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Parser.Executors.Handlers
{
    /// <summary>
    /// Handles node that are only responsible for executing their children.
    /// </summary>
    public class HandleStatements : ExecutorHandler
    {
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.Program,
                                                                        GrammarSymbol.Statements
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public HandleStatements(iExecutor pExecutor)
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