using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Parser.Executors.Handlers
{
    /// <summary>
    /// Handles the execution of a for loop.
    /// </summary>
    public class HandleLoopFor : ExecutorHandler
    {
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.ForControl,
                                                                        GrammarSymbol.ForStepControl
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public HandleLoopFor(iExecutor pExecutor)
            : base(pExecutor, _nodeTypes)
        {
        }

        /// <summary>
        /// Handle execution of a node.
        /// </summary>
        public override DataType Handle(Node pParent)
        {
#if DEBUG
            ExecutorAssert.Children(pParent, (pParent.Type == GrammarSymbol.ForControl) ? 3 : 4);
            ExecutorAssert.Data(pParent, 1);
#endif
            return UndefinedType.Undefined;
        }
    }
}