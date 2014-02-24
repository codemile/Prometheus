using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Parser.Executors.Handlers
{
    /// <summary>
    /// These nodes don't need to be executed. Their first data member can be given as the result.
    /// </summary>
    public class HandleValue : ExecutorHandler
    {
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.ValidID,
                                                                        //GrammarSymbol.Value,
                                                                        GrammarSymbol.MemberID,
                                                                        GrammarSymbol.ImportDecl
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public HandleValue(iExecutor pExecutor)
            : base(pExecutor, _nodeTypes)
        {
        }

        /// <summary>
        /// Handle execution of a node.
        /// </summary>
        public override DataType Handle(Node pNode)
        {
#if DEBUG
            ExecutorAssert.Data(pNode, 1);
#endif
            return pNode.Data[0];
        }
    }
}