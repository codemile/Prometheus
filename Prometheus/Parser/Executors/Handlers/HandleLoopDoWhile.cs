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
        public override DataType Handle(Node pParent)
        {
#if DEBUG
            ExecutorAssert.Children(pParent, 2);
#endif
            try
            {
                do
                {
                    try
                    {
                        Executor.WalkDownChildren(pParent.Children[0]);
                    }
                    catch (ContinueException)
                    {
                    }
                } while (pParent.Type == GrammarSymbol.LoopWhileControl
                    ? Executor.WalkDownChildren(pParent.Children[1]).getBool()
                    : !Executor.WalkDownChildren(pParent.Children[1]).getBool());
            }
            catch (BreakException)
            {
            }
            return UndefinedType.Undefined;
        }
    }
}