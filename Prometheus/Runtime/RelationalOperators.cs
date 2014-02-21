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
        /// Used to recursively compare arrays.
        /// </summary>
        public static bool DataEqual(DataType pValue1, DataType pValue2)
        {
            // same object reference
            if (pValue1 == pValue2)
            {
                return true;
            }

            // compare strings
            StringType str1 = pValue1 as StringType;
            StringType str2 = pValue2 as StringType;
            if (str1 != null && str2 != null)
            {
                return str1.IgnoreCase || str2.IgnoreCase
                    ? String.Compare(str1.Value, str2.Value, StringComparison.CurrentCultureIgnoreCase) == 0
                    : String.CompareOrdinal(str1.Value, str2.Value) == 0;
            }

            // compare numbers
            NumericType num1 = pValue1 as NumericType;
            NumericType num2 = pValue2 as NumericType;
            if (num1 != null && num2 != null)
            {
                if (num1.Type == num2.Type && num1.isLong)
                {
                    return num1.Long == num2.Long;
                }
                return Math.Abs(num1.Double - num2.Double) < 0.0000000000001;
            }

            // compare boolean
            BooleanType bool1 = pValue1 as BooleanType;
            BooleanType bool2 = pValue2 as BooleanType;
            if (bool1 != null && bool2 != null)
            {
                return bool1.Value == bool2.Value;
            }

            // compare pointers
            InstanceType inst1 = pValue1 as InstanceType;
            InstanceType inst2 = pValue2 as InstanceType;
            if (inst1 != null && inst2 != null)
            {
                return inst1 == inst2;
            }

            // compare with undefined
            UndefinedType undefined1 = pValue1 as UndefinedType;
            UndefinedType undefined2 = pValue2 as UndefinedType;
            if (undefined1 != null && undefined2 != null)
            {
                return true;
            }
            if (undefined1 != null || undefined2 != null)
            {
                return false;
            }

            // TODO: This might get stuck in a recursion loop if the array contains a reference to the same array twice
            // compare array
            ArrayType array1 = pValue1 as ArrayType;
            ArrayType array2 = pValue2 as ArrayType;
            if (array1 != null && array2 != null)
            {
                if (array1.Count != array2.Count)
                {
                    return false;
                }
                bool result = true;
                for (int i = 0, c = array1.Count; i < c; i++)
                {
                    result &= DataEqual(array1[i], array2[i]);
                }
                return result;
            }

            return false;
        }

        /// <summary>
        /// Checks if an array contains a data type using relational equals operator.
        /// </summary>
        public static bool Contains(ArrayType pArr, DataType pValue)
        {
            for (int i = 0, c = pArr.Values.Count; i < c; i++)
            {
                if (DataEqual(pArr.Values[i], pValue))
                {
                    return true;
                }
            }
            return false;
        }

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
                                  GrammarSymbol.EqualOperator,
                                  GrammarSymbol.NotEqualOperator,
                                  GrammarSymbol.AndOperator,
                                  GrammarSymbol.OrOperator
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
                case GrammarSymbol.NotEqualOperator:
                    reduced.Data.Add(NotEqual(valueA, valueB));
                    break;
                case GrammarSymbol.AndOperator:
                    reduced.Data.Add(AndOp(valueA, valueB));
                    break;
                case GrammarSymbol.OrOperator:
                    reduced.Data.Add(OrOp(valueA, valueB));
                    break;
            }

            return reduced;
        }

        /// <summary>
        /// AND operator
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.AndOperator)]
        public DataType AndOp(DataType pValue1, DataType pValue2)
        {
            pValue1 = Resolve(pValue1);
            pValue2 = Resolve(pValue2);

            BooleanType bool1 = pValue1 as BooleanType;
            BooleanType bool2 = pValue2 as BooleanType;
            if (bool1 != null && bool2 != null)
            {
                return new BooleanType(bool1.Value && bool2.Value);
            }

            throw DataTypeException.InvalidTypes("AND", pValue1, pValue2);
        }

        /// <summary>
        /// ~ operator
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.BitInvertOperator)]
        public DataType Bitwise(DataType pValue)
        {
            pValue = Resolve(pValue);

            NumericType num = pValue as NumericType;
            if (num != null && num.isLong)
            {
                return new NumericType(~num.Long);
            }

            throw DataTypeException.InvalidTypes("~", pValue);
        }

        /// <summary>
        /// Equal
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.EqualOperator)]
        public DataType Equal(DataType pValue1, DataType pValue2)
        {
            DataType data1 = Resolve(pValue1);
            DataType data2 = Resolve(pValue2);
            return new BooleanType(DataEqual(data1, data2));
        }

        /// <summary>
        /// Not operator
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.NotOperator)]
        public DataType Equal(DataType pValue1)
        {
            pValue1 = Resolve(pValue1);

            BooleanType bool1 = pValue1 as BooleanType;
            if (bool1 != null)
            {
                return new BooleanType(!bool1.Value);
            }

            throw DataTypeException.InvalidTypes("NOT", pValue1);
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.GtOperator)]
        public DataType GreaterThan(DataType pValue1, DataType pValue2)
        {
            pValue1 = Resolve(pValue1);
            pValue2 = Resolve(pValue2);

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
                    return new BooleanType(num1.Long > num2.Long);
                }
                return new BooleanType(num1.Double > num2.Double);
            }

            throw DataTypeException.InvalidTypes(">", pValue1, pValue2);
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.GteOperator)]
        public DataType GreaterThanEqual(DataType pValue1, DataType pValue2)
        {
            pValue1 = Resolve(pValue1);
            pValue2 = Resolve(pValue2);

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
                    return new BooleanType(num1.Long >= num2.Long);
                }
                return new BooleanType(num1.Double >= num2.Double);
            }

            throw DataTypeException.InvalidTypes(">=", pValue1, pValue2);
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.LtOperator)]
        public DataType LessThan(DataType pValue1, DataType pValue2)
        {
            pValue1 = Resolve(pValue1);
            pValue2 = Resolve(pValue2);

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
                    return new BooleanType(num1.Long < num2.Long);
                }
                return new BooleanType(num1.Double < num2.Double);
            }

            throw DataTypeException.InvalidTypes("<", pValue1, pValue2);
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.LteOperator)]
        public DataType LessThanEqual(DataType pValue1, DataType pValue2)
        {
            pValue1 = Resolve(pValue1);
            pValue2 = Resolve(pValue2);

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
                    return new BooleanType(num1.Long <= num2.Long);
                }
                return new BooleanType(num1.Double <= num2.Double);
            }

            throw DataTypeException.InvalidTypes("<=", pValue1, pValue2);
        }

        /// <summary>
        /// - operator
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.NegOperator)]
        public DataType Negative(DataType pValue)
        {
            pValue = Resolve(pValue);

            NumericType num = pValue as NumericType;
            if (num != null)
            {
                return num.isLong
                    ? new NumericType(-num.Long)
                    : new NumericType(-num.Double);
            }
            throw DataTypeException.InvalidTypes("-", pValue);
        }

        /// <summary>
        /// Not equal
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.NotEqualOperator)]
        public DataType NotEqual(DataType pValue1, DataType pValue2)
        {
            pValue1 = Resolve(pValue1);
            pValue2 = Resolve(pValue2);

            return new BooleanType(!DataEqual(pValue1, pValue2));
        }

        /// <summary>
        /// OR operator
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.OrOperator)]
        public DataType OrOp(DataType pValue1, DataType pValue2)
        {
            pValue1 = Resolve(pValue1);
            pValue2 = Resolve(pValue2);

            BooleanType bool1 = pValue1 as BooleanType;
            BooleanType bool2 = pValue2 as BooleanType;
            if (bool1 != null && bool2 != null)
            {
                return new BooleanType(bool1.Value || bool2.Value);
            }

            throw DataTypeException.InvalidTypes("OR", pValue1, pValue2);
        }

        /// <summary>
        /// + operator
        /// Doesn't change the value, but can only work on numeric types.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.PlusOperator)]
        public DataType Plus(DataType pValue)
        {
            pValue = Resolve(pValue);

            NumericType num = pValue as NumericType;
            if (num != null)
            {
                return num;
            }
            throw DataTypeException.InvalidTypes("+", pValue);
        }

        /// <summary>
        /// x-- operator
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.PostDecOperator)]
        public DataType PostDec(DataType pValue)
        {
            pValue = Resolve(pValue);

            QualifiedType id = pValue as QualifiedType;
            if (id == null)
            {
                throw DataTypeException.InvalidTypes("-", pValue);
            }

            iVariablePointer pointer = Executor.Cursor.Resolve(id);
            NumericType num = pointer.Read() as NumericType;
            if (num == null)
            {
                throw DataTypeException.InvalidTypes("-", pValue);
            }

            num = num.isLong
                ? new NumericType(num.Long - 1)
                : new NumericType(num.Double - 1.0);
            pointer.Write(num);
            return num;
        }

        /// <summary>
        /// x++ operator
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.PostIncOperator)]
        public DataType PostInc(DataType pValue)
        {
            pValue = Resolve(pValue);

            QualifiedType id = pValue as QualifiedType;
            if (id == null)
            {
                throw DataTypeException.InvalidTypes("-", pValue);
            }

            iVariablePointer pointer = Executor.Cursor.Resolve(id);
            NumericType num = pointer.Read() as NumericType;
            if (num == null)
            {
                throw DataTypeException.InvalidTypes("-", pValue);
            }

            num = num.isLong
                ? new NumericType(num.Long + 1)
                : new NumericType(num.Double + 1.0);
            pointer.Write(num);

            return num;
        }

        /// <summary>
        /// --x operator
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.PreDecOperator)]
        public DataType PreDec(DataType pValue)
        {
            pValue = Resolve(pValue);

            QualifiedType id = pValue as QualifiedType;
            if (id == null)
            {
                throw DataTypeException.InvalidTypes("-", pValue);
            }

            iVariablePointer pointer = Executor.Cursor.Resolve(id);
            NumericType num = pointer.Read() as NumericType;
            if (num == null)
            {
                throw DataTypeException.InvalidTypes("-", pValue);
            }

            pointer.Write(num.isLong
                ? new NumericType(num.Long - 1)
                : new NumericType(num.Double - 1.0));
            return num;
        }

        /// <summary>
        /// ++x operator
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.PreIncOperator)]
        public DataType PreInc(DataType pValue)
        {
            pValue = Resolve(pValue);

            QualifiedType id = pValue as QualifiedType;
            if (id == null)
            {
                throw DataTypeException.InvalidTypes("-", pValue);
            }

            iVariablePointer pointer = Executor.Cursor.Resolve(id);
            NumericType num = pointer.Read() as NumericType;
            if (num == null)
            {
                throw DataTypeException.InvalidTypes("-", pValue);
            }

            pointer.Write(num.isLong
                ? new NumericType(num.Long + 1)
                : new NumericType(num.Double + 1.0));
            return num;
        }
    }
}