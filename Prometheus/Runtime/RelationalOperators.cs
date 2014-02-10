using System;
using System.Collections.Generic;
using Prometheus.Compile.Optomizer;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Parser.Executors;
using Prometheus.Parser.Executors.Attributes;

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

            iDataType valueA = pNode.Children[0].Data[0];
            iDataType valueB = pNode.Children[1].Data[0];

            if (valueA.GetType() == typeof (IntegerType) && valueB.GetType() == typeof (IntegerType))
            {
                IntegerType a = (IntegerType)valueA;
                IntegerType b = (IntegerType)valueB;
                switch (pNode.Type)
                {
                    case GrammarSymbol.GtOperator:
                        reduced.Data.Add(GreaterThan(a, b));
                        break;
                    case GrammarSymbol.LtOperator:
                        reduced.Data.Add(LessThan(a, b));
                        break;
                    case GrammarSymbol.GteOperator:
                        reduced.Data.Add(GreaterThanEqual(a, b));
                        break;
                    case GrammarSymbol.LteOperator:
                        reduced.Data.Add(LessThanEqual(a, b));
                        break;
                    case GrammarSymbol.EqualOperator:
                        reduced.Data.Add(Equal(a, b));
                        break;
                }
            }

            if (valueA.GetType() == typeof (FloatType) && valueB.GetType() == typeof (FloatType))
            {
                FloatType a = (FloatType)valueA;
                FloatType b = (FloatType)valueB;
                switch (pNode.Type)
                {
                    case GrammarSymbol.GtOperator:
                        reduced.Data.Add(GreaterThan(a, b));
                        break;
                    case GrammarSymbol.LtOperator:
                        reduced.Data.Add(LessThan(a, b));
                        break;
                    case GrammarSymbol.GteOperator:
                        reduced.Data.Add(GreaterThanEqual(a, b));
                        break;
                    case GrammarSymbol.LteOperator:
                        reduced.Data.Add(LessThanEqual(a, b));
                        break;
                    case GrammarSymbol.EqualOperator:
                        reduced.Data.Add(Equal(a, b));
                        break;
                }
            }

            return reduced;
        }

        /// <summary>
        /// Equal
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.EqualOperator)]
        public BooleanType Equal(IntegerType pValue1, IntegerType pValue2)
        {
            return new BooleanType(pValue1.Value == pValue2.Value);
        }

        /// <summary>
        /// Equal
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.EqualOperator)]
        public BooleanType Equal(StringType pValue1, StringType pValue2)
        {
            return new BooleanType(pValue1.Value == pValue2.Value);
        }

        /// <summary>
        /// Equal
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.EqualOperator)]
        public BooleanType Equal(FloatType pValue1, FloatType pValue2)
        {
            return new BooleanType(Math.Abs(pValue1.Value - pValue2.Value) < double.Epsilon);
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.GtOperator)]
        public BooleanType GreaterThan(IntegerType pValue1, IntegerType pValue2)
        {
            return new BooleanType(pValue1.Value > pValue2.Value);
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.GtOperator)]
        public BooleanType GreaterThan(FloatType pValue1, FloatType pValue2)
        {
            return new BooleanType(pValue1.Value > pValue2.Value);
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.GteOperator)]
        public BooleanType GreaterThanEqual(IntegerType pValue1, IntegerType pValue2)
        {
            return new BooleanType(pValue1.Value >= pValue2.Value);
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.GteOperator)]
        public BooleanType GreaterThanEqual(FloatType pValue1, FloatType pValue2)
        {
            return new BooleanType(pValue1.Value >= pValue2.Value);
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.LtOperator)]
        public BooleanType LessThan(IntegerType pValue1, IntegerType pValue2)
        {
            return new BooleanType(pValue1.Value < pValue2.Value);
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.LtOperator)]
        public BooleanType LessThan(FloatType pValue1, FloatType pValue2)
        {
            return new BooleanType(pValue1.Value < pValue2.Value);
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.LteOperator)]
        public BooleanType LessThanEqual(IntegerType pValue1, IntegerType pValue2)
        {
            return new BooleanType(pValue1.Value <= pValue2.Value);
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.LteOperator)]
        public BooleanType LessThanEqual(FloatType pValue1, FloatType pValue2)
        {
            return new BooleanType(pValue1.Value <= pValue2.Value);
        }
    }
}