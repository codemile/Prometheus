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
        public override DataType Handle(Node pParent)
        {
#if DEBUG
            ExecutorAssert.Children(pParent, 2);
#endif
            try
            {
                while (pParent.Type == GrammarSymbol.DoWhileControl
                    ? Executor.WalkDownChildren(pParent.FirstChild()).getBool()
                    : !Executor.WalkDownChildren(pParent.FirstChild()).getBool())
                {
                    try
                    {
                        Executor.WalkDownChildren(pParent.Children[1]);
                    }
                    catch (ContinueException)
                    {
                    }
                }
            }
            catch (BreakException)
            {
            }
            return UndefinedType.Undefined;
        }
    }
}