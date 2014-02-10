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
    /// Handles basic math operations.
    /// </summary>
    public class MathOperators : ExecutorGrammar, iNodeOptimizer
    {
        /// <summary>
        /// A list of math operations
        /// </summary>
        private readonly HashSet<GrammarSymbol> _mathSymbols;

        /// <summary>
        /// Checks if a node performs math operations on two constant values.
        /// </summary>
        /// <param name="pNode">The node to check</param>
        /// <returns>True if it can be reduced.</returns>
        private bool CanReduce(Node pNode)
        {
            return (_mathSymbols.Contains(pNode.Type) &&
                    pNode.Children[0].Type == GrammarSymbol.Value &&
                    pNode.Children[1].Type == GrammarSymbol.Value);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public MathOperators(Executor pExecutor)
            : base(pExecutor)
        {
            _mathSymbols = new HashSet<GrammarSymbol>
                           {
                               GrammarSymbol.AddExpression,
                               GrammarSymbol.SubExpression,
                               GrammarSymbol.MultiplyExpression,
                               GrammarSymbol.DivideExpression
                           };
        }

        /// <summary>
        /// Reduces the node to just a constant value.
        /// </summary>
        /// <param name="pNode">The node to reduce</param>
        /// <returns>Same node or a new node.</returns>
        public Node Optomize(Node pNode)
        {
            if (pNode.Children.Count != 2 ||
                pNode.Data.Count != 0 ||
                !CanReduce(pNode))
            {
                return pNode;
            }

            // do math operation now
            Node reduced = new Node(GrammarSymbol.Value, pNode.Location);

            iDataType valueA = pNode.Children[0].Data[0];
            iDataType valueB = pNode.Children[1].Data[0];

            if (valueA.GetType() == typeof (IntegerType) && valueB.GetType() == typeof (IntegerType))
            {
                IntegerType a = (IntegerType)valueA;
                IntegerType b = (IntegerType)valueB;
                switch (pNode.Type)
                {
                    case GrammarSymbol.AddExpression:
                        reduced.Data.Add(Add(a, b));
                        break;
                    case GrammarSymbol.SubExpression:
                        reduced.Data.Add(Sub(a, b));
                        break;
                    case GrammarSymbol.MultiplyExpression:
                        reduced.Data.Add(Mul(a, b));
                        break;
                    case GrammarSymbol.DivideExpression:
                        reduced.Data.Add(Div(a, b));
                        break;
                }
            }

            if (valueA.GetType() == typeof (FloatType) && valueB.GetType() == typeof (FloatType))
            {
                FloatType a = (FloatType)valueA;
                FloatType b = (FloatType)valueB;
                switch (pNode.Type)
                {
                    case GrammarSymbol.AddExpression:
                        reduced.Data.Add(Add(a, b));
                        break;
                    case GrammarSymbol.SubExpression:
                        reduced.Data.Add(Sub(a, b));
                        break;
                    case GrammarSymbol.MultiplyExpression:
                        reduced.Data.Add(Mul(a, b));
                        break;
                    case GrammarSymbol.DivideExpression:
                        reduced.Data.Add(Div(a, b));
                        break;
                }
            }

            return reduced;
        }

        /// <summary>
        /// Addition
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.AddExpression)]
        public StringType Add(StringType pValue1, StringType pValue2)
        {
            return new StringType(string.Concat(pValue1.Value, pValue2.Value));
        }

        /// <summary>
        /// Addition
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.AddExpression)]
        public IntegerType Add(IntegerType pValue1, IntegerType pValue2)
        {
            return new IntegerType(pValue1.Value + pValue2.Value);
        }

        /// <summary>
        /// Addition
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.AddExpression)]
        public FloatType Add(FloatType pValue1, FloatType pValue2)
        {
            return new FloatType(pValue1.Value + pValue2.Value);
        }

        /// <summary>
        /// Division
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.DivideExpression)]
        public IntegerType Div(IntegerType pValue1, IntegerType pValue2)
        {
            return new IntegerType(pValue1.Value / pValue2.Value);
        }

        /// <summary>
        /// Division
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.DivideExpression)]
        public FloatType Div(FloatType pValue1, FloatType pValue2)
        {
            return new FloatType(pValue1.Value / pValue2.Value);
        }

        /// <summary>
        /// Multiplication
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.MultiplyExpression)]
        public IntegerType Mul(IntegerType pValue1, IntegerType pValue2)
        {
            return new IntegerType(pValue1.Value * pValue2.Value);
        }

        /// <summary>
        /// Multiplication
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.MultiplyExpression)]
        public FloatType Mul(FloatType pValue1, FloatType pValue2)
        {
            return new FloatType(pValue1.Value * pValue2.Value);
        }

        /// <summary>
        /// Subtraction
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.SubExpression)]
        public IntegerType Sub(IntegerType pValue1, IntegerType pValue2)
        {
            return new IntegerType(pValue1.Value - pValue2.Value);
        }

        /// <summary>
        /// Subtraction
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.SubExpression)]
        public FloatType Sub(FloatType pValue1, FloatType pValue2)
        {
            return new FloatType(pValue1.Value - pValue2.Value);
        }
    }
}