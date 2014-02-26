using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Parser.Executors.Handlers
{
    /// <summary>
    /// Handles the creation of arrays.
    /// </summary>
    public class HandleArrays : ExecutorHandler
    {
        /// <summary>
        /// Supported node types
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.ArrayLiteral,
                                                                        GrammarSymbol.ArgumentArray,
                                                                        GrammarSymbol.ParameterArray,
                                                                        GrammarSymbol.TestSuiteArray,
                                                                        GrammarSymbol.QualifiedID,
                                                                        GrammarSymbol.ClassNameID
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public HandleArrays(iExecutor pExecutor)
            : base(pExecutor, _nodeTypes)
        {
        }

        /// <summary>
        /// Handle execution of a node.
        /// </summary>
        public override DataType Handle(Node pNode)
        {
            IList<DataType> array;
            switch (pNode.Symbol)
            {
                case GrammarSymbol.QualifiedID:
                case GrammarSymbol.ClassNameID:
                    array = new QualifiedType();
                    break;
                default:
                    array = new ArrayType();
                    break;
            }
            for (int i = 0, c = pNode.Children.Count; i < c; i++)
            {
#if DEBUG
                if (pNode.Symbol == GrammarSymbol.ParameterArray)
                {
                    ExecutorAssert.Data(pNode.Children[i], 1);
                    ExecutorAssert.DataType(pNode.Children[i], 0, typeof (IdentifierType));
                }
#endif
                array.Add(pNode.Symbol == GrammarSymbol.ParameterArray
                    ? pNode.Children[i].Data[0]
                    : Executor.WalkDownChildren(pNode.Children[i]));
            }
            return (DataType)array;
        }
    }
}