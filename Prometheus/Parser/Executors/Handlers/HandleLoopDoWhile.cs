using System.Collections.Generic;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Parser.Executors.Handlers
{
    /// <summary>
    /// Handles the execution of do/while loops.
    /// </summary>
    public class HandleLoopDoWhile : ExecutorHandler
    {
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.LoopWhileControl,
                                                                        GrammarSymbol.LoopUntilControl
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public HandleLoopDoWhile(iExecutor pExecutor)
            : base(pExecutor, _nodeTypes)
        {
        }

        /// <summary>
        /// Handle execution of a node.
        /// </summary>
        public override DataType Handle(Node pNode)
        {
#if DEBUG
            ExecutorAssert.Children(pNode, 2);
#endif
            Node whileBlock = pNode.Children[0];
            Node whileCondition = pNode.Children[1];

            try
            {
                do
                {
                    ExecuteBlock(whileBlock);
                } while (pNode.Type == GrammarSymbol.LoopWhileControl
                    ? Executor.WalkDownChildren(whileCondition).getBool()
                    : !Executor.WalkDownChildren(whileCondition).getBool());
            }
            catch (BreakException)
            {
            }
            return UndefinedType.Undefined;
        }
    }
}