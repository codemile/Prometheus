using System;
using System.Collections.Generic;
using Prometheus.Compile.Optomizer;
using Prometheus.Exceptions.Executor;
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

            DataType valueA = pNode.Children[0].Data[0];
            DataType valueB = pNode.Children[1].Data[0];

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
        public DataType Equal(DataType pValue1, DataType pValue2)
        {
            StringType str1 = pValue1 as StringType;
            StringType str2 = pValue2 as StringType;
            if (str1 != null && str2 != null)
            {
                return new BooleanType(String.CompareOrdinal(str1.Value, str2.Value) == 0);
            }

            NumericType num1 = pValue1 as NumericType;
            NumericType num2 = pValue2 as NumericType;
            if (num1 != null && num2 != null)
            {
                if (num1.Type == num2.Type && num1.Type == typeof (long))
                {
                    return new BooleanType(num1.getLong() == num2.getLong());
                }
                return new BooleanType(Math.Abs(num1.getDouble() - num2.getDouble()) < double.Epsilon);
            }

            throw DataTypeException.InvalidTypes("==", pValue1, pValue2);
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.GtOperator)]
        public DataType GreaterThan(DataType pValue1, DataType pValue2)
        {
            StringType str1 = pValue1 as StringType;
            StringType str2 = pValue2 as StringType;
            if (str1 != null && str2 != null)
            {
                return new BooleanType(String.CompareOrdinal(str1.Value, str2.Value) > 0);
            }

            NumericType num1 = pValue1 as NumericType;
            NumericType num2 = pValue2 as NumericType;
            if (num1 != null && num2 != null)
            {
                if (num1.Type == num2.Type && num1.Type == typeof (long))
                {
                    return new BooleanType(num1.getLong() > num2.getLong());
                }
                return new BooleanType(num1.getDouble() > num2.getDouble());
            }

            throw DataTypeException.InvalidTypes(">", pValue1, pValue2);
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.GteOperator)]
        public DataType GreaterThanEqual(DataType pValue1, DataType pValue2)
        {
            StringType str1 = pValue1 as StringType;
            StringType str2 = pValue2 as StringType;
            if (str1 != null && str2 != null)
            {
                return new BooleanType(String.CompareOrdinal(str1.Value, str2.Value) >= 0);
            }

            NumericType num1 = pValue1 as NumericType;
            NumericType num2 = pValue2 as NumericType;
            if (num1 != null && num2 != null)
            {
                if (num1.Type == num2.Type && num1.Type == typeof (long))
                {
                    return new BooleanType(num1.getLong() >= num2.getLong());
                }
                return new BooleanType(num1.getDouble() >= num2.getDouble());
            }

            throw DataTypeException.InvalidTypes(">=", pValue1, pValue2);
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.LtOperator)]
        public DataType LessThan(DataType pValue1, DataType pValue2)
        {
            StringType str1 = pValue1 as StringType;
            StringType str2 = pValue2 as StringType;
            if (str1 != null && str2 != null)
            {
                return new BooleanType(String.CompareOrdinal(str1.Value, str2.Value) < 0);
            }

            NumericType num1 = pValue1 as NumericType;
            NumericType num2 = pValue2 as NumericType;
            if (num1 != null && num2 != null)
            {
                if (num1.Type == num2.Type && num1.Type == typeof (long))
                {
                    return new BooleanType(num1.getLong() < num2.getLong());
                }
                return new BooleanType(num1.getDouble() < num2.getDouble());
            }

            throw DataTypeException.InvalidTypes("<", pValue1, pValue2);
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.LteOperator)]
        public DataType LessThanEqual(DataType pValue1, DataType pValue2)
        {
            StringType str1 = pValue1 as StringType;
            StringType str2 = pValue2 as StringType;
            if (str1 != null && str2 != null)
            {
                return new BooleanType(String.CompareOrdinal(str1.Value, str2.Value) <= 0);
            }

            NumericType num1 = pValue1 as NumericType;
            NumericType num2 = pValue2 as NumericType;
            if (num1 != null && num2 != null)
            {
                if (num1.Type == num2.Type && num1.Type == typeof (long))
                {
                    return new BooleanType(num1.getLong() <= num2.getLong());
                }
                return new BooleanType(num1.getDouble() <= num2.getDouble());
            }

            throw DataTypeException.InvalidTypes("<=", pValue1, pValue2);
        }
    }
}