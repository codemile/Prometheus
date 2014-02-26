using System;
using System.Collections.Generic;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Parser.Executors.Handlers
{
    /// <summary>
    /// Handles node that generate runtime exceptions.
    /// </summary>
    public class HandleExceptions : ExecutorHandler
    {
        /// <summary>
        /// The node types
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.BreakControl,
                                                                        GrammarSymbol.ContinueControl
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public HandleExceptions(iExecutor pExecutor)
            : base(pExecutor, _nodeTypes)
        {
        }

        /// <summary>
        /// Handle execution of a node.
        /// </summary>
        public override DataType Handle(Node pNode)
        {
            if (pNode.Symbol == GrammarSymbol.BreakControl)
            {
                throw new BreakException(pNode);
            }
            if (pNode.Symbol == GrammarSymbol.ContinueControl)
            {
                throw new ContinueException(pNode);
            }
            throw new NotImplementedException();
        }
    }
}