using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Parser.Executors.Handlers
{
    /// <summary>
    /// Changes blocks into a function data type that can be executed.
    /// </summary>
    public class HandleBlock : ExecutorHandler
    {
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.Block
                                                                    };

        /// <summary>
        /// The code for statements handler
        /// </summary>
        private readonly int _code;

        /// <summary>
        /// Constructor
        /// </summary>
        public HandleBlock(iExecutor pExecutor)
            : base(pExecutor, _nodeTypes)
        {
            HandleStatements statements = new HandleStatements(pExecutor);
            _code = statements.GetHandlerCode();
        }

        /// <summary>
        /// Creates a new statements node from the block.
        /// </summary>
        public override DataType Handle(Node pNode)
        {
            return new FunctionType(HandleStatements.Create(pNode));
        }
    }
}