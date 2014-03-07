using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Parser.Executors.Handlers
{
    /// <summary>
    /// Handles the definition of parameters for a declaration.
    /// </summary>
    public class HandleParameters : ExecutorHandler
    {
        /// <summary>
        /// Supported node types
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.ParameterArray,
                                                                        GrammarSymbol.WithArray
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public HandleParameters(iExecutor pExecutor)
            : base(pExecutor, _nodeTypes)
        {
        }

        /// <summary>
        /// Handle execution of a node.
        /// </summary>
        public override DataType Handle(Node pNode)
        {
            IList<DataType> array = new ArrayType();
            for (int i = 0, c = pNode.Children.Count; i < c; i++)
            {
#if DEBUG
                    ExecutorAssert.Data(pNode.Children[i], 1);
                    ExecutorAssert.DataType(pNode.Children[i], 0, typeof (IdentifierType));
#endif
                array.Add(pNode.Children[i].Data[0]);
            }
            return (DataType)array;
        }
    }
}