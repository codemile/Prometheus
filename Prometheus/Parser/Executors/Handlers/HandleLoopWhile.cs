using System.Collections.Generic;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Parser.Executors.Handlers
{
    /// <summary>
    /// Handles the execution of while loops.
    /// </summary>
    public class HandleLoopWhile : ExecutorHandler
    {
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.DoWhileControl,
                                                                        GrammarSymbol.DoUntilControl
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public HandleLoopWhile(iExecutor pExecutor)
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
            Node whileCondition = pNode.Children[0];
            Node whileBlock = pNode.Children[1];

            try
            {
                while (pNode.Type == GrammarSymbol.DoWhileControl
                    ? Executor.WalkDownChildren(whileCondition).getBool()
                    : !Executor.WalkDownChildren(whileCondition).getBool())
                {
                    ExecuteBlock(whileBlock);
                }
            }
            catch (BreakException)
            {
            }
            return UndefinedType.Undefined;
        }
    }
}