using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
                               GrammarSymbol.DivideExpression,
                               GrammarSymbol.RemainderExpression
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

            DataType valueA = pNode.Children[0].Data[0];
            DataType valueB = pNode.Children[1].Data[0];

            switch (pNode.Type)
            {
                case GrammarSymbol.AddExpression:
                    reduced.Data.Add(Add(valueA, valueB));
                    break;
                case GrammarSymbol.SubExpression:
                    reduced.Data.Add(Sub(valueA, valueB));
                    break;
                case GrammarSymbol.MultiplyExpression:
                    reduced.Data.Add(Mul(valueA, valueB));
                    break;
                case GrammarSymbol.DivideExpression:
                    reduced.Data.Add(Div(valueA, valueB));
                    break;
                case GrammarSymbol.RemainderExpression:
                    reduced.Data.Add(Remainder(valueA, valueB));
                    break;
            }

            return reduced;
        }

        /// <summary>
        /// Addition
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.AddExpression)]
        public DataType Add(DataType pValue1, DataType pValue2)
        {
            pValue1 = Resolve(pValue1);
            pValue2 = Resolve(pValue2);

            StringType str1 = pValue1 as StringType;
            StringType str2 = pValue2 as StringType;
            if (str1 != null && str2 != null)
            {
                return new StringType(str1, str2);
            }

            NumericType num1 = pValue1 as NumericType;
            NumericType num2 = pValue2 as NumericType;
            if (num1 != null && num2 != null)
            {
                return num1.isLong
                    ? new NumericType(num1.Long + num2.Long)
                    : new NumericType(num1.Double + num2.Double);
            }

            ArrayType arr1 = pValue1 as ArrayType;
            ArrayType arr2 = pValue2 as ArrayType;
            if (arr1 != null && arr2 != null)
            {
                ArrayType arr = (ArrayType)arr1.Clone();
                for (int i = 0, c = arr2.Count; i < c; i++)
                {
                    arr.Values.Add(arr2[i].Clone());
                }
                return arr;
            }

            throw DataTypeException.InvalidTypes("+", pValue1, pValue2);
        }

        /// <summary>
        /// Division
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.DivideExpression)]
        public DataType Div(DataType pValue1, DataType pValue2)
        {
            pValue1 = Resolve(pValue1);
            pValue2 = Resolve(pValue2);

            NumericType num1 = pValue1 as NumericType;
            NumericType num2 = pValue2 as NumericType;
            if (num1 != null && num2 != null)
            {
                try
                {
                    return new NumericType(num1.Double / num2.Double);
                }
                catch (DivideByZeroException e)
                {
                    throw new DivideByZeroPrometheusException(e.Message, e);
                }
            }

            StringType str1 = pValue1 as StringType;
            StringType str2 = pValue2 as StringType;
            if (str1 != null && str2 != null)
            {
                Regex regex = str2.Compile();
                string[] strings = regex.Split(str1.Value);
                ArrayType arr = new ArrayType(strings.Length);
                for (int i = 0, c = strings.Length; i < c; i++)
                {
                    arr.Add(new StringType(str1.IsRegex, strings[i], str1.Mode, str1.Flags));
                }
                return arr;
            }

            ArrayType arr1 = pValue1 as ArrayType;
            if (arr1 != null
                && num2 != null
                && num2.isLong)
            {
                int length = (int)num2.Long;
                if (length > arr1.Count)
                {
                    return arr1;
                }
                ArrayType arr = new ArrayType(length);
                for (int i = 0; i < length; i++)
                {
                    arr.Add(arr1[i].Clone());
                }
                return arr;
            }

            throw DataTypeException.InvalidTypes("/", pValue1, pValue2);
        }

        /// <summary>
        /// Multiplication
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.MultiplyExpression)]
        public DataType Mul(DataType pValue1, DataType pValue2)
        {
            pValue1 = Resolve(pValue1);
            pValue2 = Resolve(pValue2);

            NumericType num1 = pValue1 as NumericType;
            NumericType num2 = pValue2 as NumericType;
            if (num1 != null && num2 != null)
            {
                return num1.isLong && num2.isLong
                    ? new NumericType(num1.Long * num2.Long)
                    : new NumericType(num1.Double * num2.Double);
            }

            StringType str1 = pValue1 as StringType;
            if (str1 != null
                && num2 != null
                && num2.isLong)
            {
                StringBuilder sb = new StringBuilder();
                for (long i = 0, c = num2.Long; i < c; i++)
                {
                    sb.Append(str1.Value);
                }
                return new StringType(str1.IsRegex,sb.ToString(),str1.Mode,str1.Flags);
            }

            ArrayType arr1 = pValue1 as ArrayType;
            if (arr1 != null
                && num2 != null
                && num2.isLong)
            {
                int c = (int)num2.Long;
                ArrayType arr = new ArrayType(arr1.Count * c);
                for (int i = 0; i < c; i++)
                {
                    arr.AddRange(arr1);
                }
                return arr;
            }

            throw DataTypeException.InvalidTypes("*", pValue1, pValue2);
        }

        /// <summary>
        /// Remainder
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.RemainderExpression)]
        public DataType Remainder(DataType pValue1, DataType pValue2)
        {
            pValue1 = Resolve(pValue1);
            pValue2 = Resolve(pValue2);

            NumericType num1 = pValue1 as NumericType;
            NumericType num2 = pValue2 as NumericType;
            if (num1 != null && num2 != null)
            {
                return num1.isLong && num2.isLong
                    ? new NumericType(num1.Long % num2.Long)
                    : new NumericType(num1.Double % num2.Double);
            }

            ArrayType arr1 = pValue1 as ArrayType;
            if (arr1 != null
                && num2 != null
                && num2.isLong
                && num2.Long >= 0)
            {
                int c = Math.Min((int)num2.Long, arr1.Count);
                if (c == 0)
                {
                    return arr1.Clone();
                }
                ArrayType arr = new ArrayType(arr1.Count - c);
                for (int i = c; i < arr1.Count; i++)
                {
                    arr.Add(arr1[i]);
                }
                return arr;
            }

            throw DataTypeException.InvalidTypes("%", pValue1, pValue2);
        }

        /// <summary>
        /// Subtraction
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.SubExpression)]
        public DataType Sub(DataType pValue1, DataType pValue2)
        {
            pValue1 = Resolve(pValue1);
            pValue2 = Resolve(pValue2);

            NumericType num1 = pValue1 as NumericType;
            NumericType num2 = pValue2 as NumericType;
            if (num1 != null && num2 != null)
            {
                return num1.isLong
                    ? new NumericType(num1.Long - num2.Long)
                    : new NumericType(num1.Double - num2.Double);
            }

            StringType str1 = pValue1 as StringType;
            StringType str2 = pValue2 as StringType;
            if (str1 != null && str2 != null)
            {
                Regex regex = str2.Compile();
                return new StringType(str1.IsRegex,regex.Replace(str1.Value, ""),str1.Mode,str1.Flags);
            }

            ArrayType arr1 = pValue1 as ArrayType;
            ArrayType arr2 = pValue2 as ArrayType;
            if (arr1 != null && arr2 != null)
            {
                ArrayType arr = new ArrayType();
                for (int i = 0, ic = arr1.Count; i < ic; i++)
                {
                    if (RelationalOperators.Contains(arr2, arr1[i]))
                    {
                        continue;
                    }
                    arr.Add(arr1[i].Clone());
                }
                return arr;
            }

            throw DataTypeException.InvalidTypes("-", pValue1, pValue2);
        }
    }
}