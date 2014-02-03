using System;
using System.Collections.Generic;
using Prometheus.Compile.Optomizer;
using Prometheus.Executors;
using Prometheus.Executors.Attributes;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Implements the operators for greater than and less than.
    /// </summary>
    public class RelationalOperators : ExecutorGrammar, iNodeOptimizer
    {
        /// <summary>
        /// A list of relational operators
        /// </summary>
        private readonly HashSet<GrammarSymbol> _compareSymbols;

        /// <summary>
        /// Checks if a node performs math operations on two constant values.
        /// </summary>
        /// <param name="pNode">The node to check</param>
        /// <returns>True if it can be reduced.</returns>
        private bool CanReduce(Node pNode)
        {
            return (_compareSymbols.Contains(pNode.Type) &&
                    pNode.Children[0].Type == GrammarSymbol.Value &&
                    pNode.Children[1].Type == GrammarSymbol.Value);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public RelationalOperators(Executor pExecutor)
            : base(pExecutor)
        {
            _compareSymbols = new HashSet<GrammarSymbol>
                              {
                                  GrammarSymbol.GtOperator,
                                  GrammarSymbol.LtOperator,
                                  GrammarSymbol.GteOperator,
                                  GrammarSymbol.LteOperator,
                                  GrammarSymbol.EqualOperator
                              };
        }

        /// <summary>
        /// Inspect a node
        /// </summary>
        /// <param name="pNode">The node to check</param>
        /// <returns>Same node, a new node or null to remove it.</returns>
        public Node Optomize(Node pNode)
        {
            if (pNode.Children.Count != 2 ||
                pNode.Data.Count != 0 ||
                !CanReduce(pNode))
            {
                return pNode;
            }

            // do relational operation now
            Node reduced = new Node(GrammarSymbol.Value, pNode.Location);

            Data valueA = pNode.Children[0].Data[0];
            Data valueB = pNode.Children[1].Data[0];

            switch (pNode.Type)
            {
                case GrammarSymbol.GtOperator:
                    reduced.Data.Add(GreaterThan(valueA, valueB));
                    break;
                case GrammarSymbol.LtOperator:
                    reduced.Data.Add(LessThan(valueA, valueB));
                    break;
                case GrammarSymbol.GteOperator:
                    reduced.Data.Add(GreaterThanEqual(valueA, valueB));
                    break;
                case GrammarSymbol.LteOperator:
                    reduced.Data.Add(LessThanEqual(valueA, valueB));
                    break;
                case GrammarSymbol.EqualOperator:
                    reduced.Data.Add(Equal(valueA, valueB));
                    break;
            }

            return reduced;
        }

        /// <summary>
        /// Equal
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.EqualOperator)]
        public Data Equal(Data pValue1, Data pValue2)
        {
            Type type = DataConverter.BestNumericType(pValue1.Type, pValue2.Type);
            return type == Data.Integer
                ? new Data(pValue1.GetInteger() == pValue2.GetInteger())
                : new Data(Math.Abs(pValue1.GetPrecise() - pValue2.GetPrecise()) < Data.PRECISE_EPSILON);
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.GtOperator)]
        public Data GreaterThan(Data pValue1, Data pValue2)
        {
            Type type = DataConverter.BestNumericType(pValue1.Type, pValue2.Type);
            return type == Data.Integer
                ? new Data(pValue1.GetInteger() > pValue2.GetInteger())
                : new Data(pValue1.GetPrecise() > pValue2.GetPrecise());
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.GteOperator)]
        public Data GreaterThanEqual(Data pValue1, Data pValue2)
        {
            Type type = DataConverter.BestNumericType(pValue1.Type, pValue2.Type);
            return type == Data.Integer
                ? new Data(pValue1.GetInteger() >= pValue2.GetInteger())
                : new Data(pValue1.GetPrecise() >= pValue2.GetPrecise());
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.LtOperator)]
        public Data LessThan(Data pValue1, Data pValue2)
        {
            Type type = DataConverter.BestNumericType(pValue1.Type, pValue2.Type);
            return type == Data.Integer
                ? new Data(pValue1.GetInteger() < pValue2.GetInteger())
                : new Data(pValue1.GetPrecise() < pValue2.GetPrecise());
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.LteOperator)]
        public Data LessThanEqual(Data pValue1, Data pValue2)
        {
            Type type = DataConverter.BestNumericType(pValue1.Type, pValue2.Type);
            return type == Data.Integer
                ? new Data(pValue1.GetInteger() <= pValue2.GetInteger())
                : new Data(pValue1.GetPrecise() <= pValue2.GetPrecise());
        }
    }
}