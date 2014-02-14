using Logging;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Objects;
using Prometheus.Parser.Executors;
using Prometheus.Parser.Executors.Attributes;
using Prometheus.Storage;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Handles symbols related to variable management
    /// </summary>
    public class Variables : ExecutorGrammar
    {
        /// <summary>
        /// Logging
        /// </summary>
        private static readonly Logger _logger = Logger.Create(typeof (Variables));

        /// <summary>
        /// Prints a memory space recursively for object instances.
        /// </summary>
        private static void Print(HeapSpace pHead, iMemoryDump pMemory, int pIndent)
        {
            foreach (MemoryItem item in pMemory.Dump(pIndent))
            {
                string indent = "";
                if (item.Level > 0)
                {
                    indent = " ".PadLeft(pIndent + item.Level);
                }
                AliasType alias = item.Data as AliasType;
                if (alias != null)
                {
                    Instance inst = pHead.Get(alias);
                    _logger.Fine("{0}{1} = {2}::{3}[",indent,item.Name,inst.ClassName,alias.Heap);
                    Print(pHead, inst.GetMembers(), pIndent + 1);
                    _logger.Fine("{0}]", indent);
                    continue;
                }
                ArrayType array = item.Data as ArrayType;
                if (array != null)
                {
                    _logger.Fine("{0}{1} = array({2})[", indent, item.Name, array.Values.Count);
                    Print(pHead, array, pIndent + 1);
                    _logger.Fine("{0}]", indent);
                    continue;
                }
                _logger.Fine("{0}{1} = {2}", indent, item.Name, item.Data);
            }
        }

        /// <summary>
        /// Will convert a function expression into a closure function with a reference
        /// to the current "this" object.
        /// </summary>
        private DataType CreateClosure(DataType pValue)
        {
            ClosureType func = pValue as ClosureType;
            if (func == null || func.isCompiled())
            {
                return pValue;
            }
            AliasType _this = (AliasType)Executor.Cursor.Stack.Get("this");
            return new ClosureType(_this, func.Function);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Variables(Executor pExecutor)
            : base(pExecutor)
        {
        }

        /// <summary>
        /// Assigns a value to an Identifier
        /// </summary>
        /// <param name="pQualified">The variable name</param>
        /// <param name="pValue">The value to assign</param>
        [ExecuteSymbol(GrammarSymbol.Assignment)]
        public DataType Assignment(QualifiedType pQualified, DataType pValue)
        {
            pValue = CreateClosure(pValue);
            Executor.Cursor.Set(pQualified, pValue);
            return pValue;
        }

        /// <summary>
        /// Decrement
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.Decrement)]
        public DataType Dec(QualifiedType pQualified)
        {
            string member = pQualified.Parts[pQualified.Parts.Length - 1];
            iMemorySpace storage = Executor.Cursor.Resolve(pQualified);
            DataType d = storage.Get(member);
            NumericType num = d as NumericType;
            if (num != null)
            {
                return num.isLong
                    ? new NumericType(num.Long + 1)
                    : new NumericType(num.Double + 1);
            }
            throw DataTypeException.InvalidTypes("++", d);
        }

        /// <summary>
        /// Declares a variable with a value
        /// </summary>
        /// <param name="pIdentifier">Name of the variable</param>
        /// <param name="pValue">The value</param>
        /// <returns>The value assigned</returns>
        [ExecuteSymbol(GrammarSymbol.Declare)]
        public DataType Declare(IdentifierType pIdentifier, DataType pValue)
        {
            pValue = CreateClosure(pValue);
            Executor.Cursor.Stack.Create(pIdentifier.Name, pValue);
            return pValue;
        }

        /// <summary>
        /// Declares a variable without a value
        /// </summary>
        /// <param name="pIdentifier">Name of the variable</param>
        /// <returns>The value assigned</returns>
        [ExecuteSymbol(GrammarSymbol.Declare)]
        public DataType Declare(IdentifierType pIdentifier)
        {
            return Declare(pIdentifier, UndefinedType.Undefined);
        }

        /// <summary>
        /// Increment
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.Increment)]
        public DataType Inc(QualifiedType pQualified)
        {
            string member = pQualified.Parts[pQualified.Parts.Length - 1];
            iMemorySpace storage = Executor.Cursor.Resolve(pQualified);
            DataType d = storage.Get(member);
            NumericType num = d as NumericType;
            if (num != null)
            {
                return num.isLong
                    ? new NumericType(num.Long - 1)
                    : new NumericType(num.Double - 1.0);
            }
            throw DataTypeException.InvalidTypes("--", d);
        }

        /// <summary>
        /// Decrement
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ListVars)]
        public DataType ListVars()
        {
            Print(Executor.Cursor.Heap, Executor.Cursor.Stack, 0);
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Returns the value of a variable.
        /// </summary>
        /// <param name="pQualifier">The variable name</param>
        /// <returns>The value or undefined.</returns>
        [ExecuteSymbol(GrammarSymbol.QualifiedID)]
        public DataType Qualified(QualifiedType pQualifier)
        {
            return Executor.Cursor.Get(pQualifier);
        }

        /// <summary>
        /// Returns the value of data stored in the source code.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.Value)]
        public DataType Value(DataType pValue)
        {
            return pValue;
        }

        /// <summary>
        /// Returns the value in an array accessed by an index offset.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ArrayOperator)]
        public DataType ArrayAccess(QualifiedType pId, ArrayType pElements)
        {
            ArrayType array = getArray(pId);
            DataType result = UndefinedType.Undefined;
            for (int i = 0, c = pElements.Count; i < c; i++)
            {
                if (i != 0)
                {
                    array = result as ArrayType;
                    if (array == null)
                    {
                        throw new InvalidIndexException(string.Format("Cannot apply indexing to an expression of type <{0}>",
                            result.GetType()));
                    }
                }
                int index = getArrayIndex(pElements.Values[i]);
                if (index < 0 || index >= array.Count)
                {
                    throw new InvalidIndexException(string.Format("Index parameter is out of range <{0}>",index));
                }
                result = array.Values[index];
            }

            return result;
        }

        /// <summary>
        /// When using a DataType to access an index of an array. This ensures it's an integer
        /// value.
        /// </summary>
        /// <param name="pValue"></param>
        /// <returns></returns>
        private static int getArrayIndex(DataType pValue)
        {
            NumericType num = pValue as NumericType;
            if (num == null)
            {
                throw new InvalidIndexException(string.Format("Cannot access array using index of type <{0}>", pValue.GetType()));
            }
            if (num.isDouble)
            {
                throw new InvalidIndexException("Cannot access array using index of type <float>");
            }
            return (int)num.Long;
        }

        /// <summary>
        /// Access the identifier as an array type.
        /// </summary>
        /// <param name="pId">The identifier</param>
        /// <returns>The array object</returns>
        private ArrayType getArray(QualifiedType pId)
        {
            // an ID or array
            DataType data = Executor.Cursor.Get(pId);
            ArrayType array = data as ArrayType;
            if (array == null)
            {
                throw new InvalidIndexException(string.Format("Cannot apply indexing to an expression of type <{0}>",
                    data.GetType()));
            }
            return array;
        }
    }
}