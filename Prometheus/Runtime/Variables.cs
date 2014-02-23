using Logging;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
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
        private static void Print(iMemoryDump pMemory, int pIndent)
        {
            foreach (MemoryItem item in pMemory.Dump(pIndent))
            {
                string indent = "";
                if (item.Level > 0)
                {
                    indent = " ".PadLeft(pIndent + item.Level);
                }
                InstanceType inst = item.Data as InstanceType;
                if (inst != null)
                {
                    _logger.Fine("{0}{1} = instance[", indent, item.Name);
                    Print(inst.GetMembers(), pIndent + 1);
                    _logger.Fine("{0}]", indent);
                    continue;
                }
                ArrayType array = item.Data as ArrayType;
                if (array != null)
                {
                    _logger.Fine("{0}{1} = array({2})[", indent, item.Name, array.Values.Count);
                    Print(array, pIndent + 1);
                    _logger.Fine("{0}]", indent);
                    continue;
                }
                _logger.Fine("{0}{1} = {2}", indent, item.Name, item.Data);
            }
        }

        /// <summary>
        /// Creates a plural data type object.
        /// </summary>
        private DataType CreatePlural(DataType pValue, IdentifierType pSingular)
        {
            ArrayType arr = pValue as ArrayType;
            if (arr == null)
            {
                throw new InvalidArgumentException(
                    string.Format("Expected array value but found <{0}> instead", pValue.GetType().Name), Cursor.Node);
            }

            return new PluralType(arr, pSingular);
        }

        /// <summary>
        /// Resolves the assignment value to a data type that
        /// can be assigned.
        /// </summary>
        private DataType ResolveToValue(DataType pValue)
        {
            pValue = Resolve(pValue);

            ClosureType func = pValue as ClosureType;
            if (func == null || func.HasThis())
            {
                return pValue;
            }

            InstanceType _this = (InstanceType)Cursor.Stack.Get(IdentifierType.THIS);
            return new ClosureType(_this, func);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Variables(Executor pExecutor)
            : base(pExecutor)
        {
        }

        /// <summary>
        /// = Assigns a value to an Identifier
        /// </summary>
        /// <param name="pId">The variable name</param>
        /// <param name="pValue">The value to assign</param>
        [ExecuteSymbol(GrammarSymbol.Assignment)]
        public DataType Assignment(QualifiedType pId, DataType pValue)
        {
            DataType value = ResolveToValue(pValue);
            Cursor.Resolve(pId).Write(value);
            return value;
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
            pValue = ResolveToValue(pValue);
            Cursor.Stack.Create(pIdentifier.Name, pValue);
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
        /// Decrement
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ListVars)]
        public DataType ListVars()
        {
            Print(Cursor.Stack, 0);
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Creates a singular identifier from a reference to a plural identifier.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.PluralID)]
        public DataType Plural(QualifiedType pId)
        {
            iVariablePointer pointer = Cursor.Resolve(pId);
            if (pointer is ArrayPointer)
            {
                throw new InvalidArgumentException(
                    "Can not singularize an array identifier. Use the AS keyword to specify singular identifier",
                    Cursor.Node);
            }
#if DEBUG
            if (!(pointer is MemoryPointer))
            {
                throw new UnexpectedErrorException("Pointer is of unexpected type", Cursor.Node);
            }
#endif
            MemoryPointer memPointer = (MemoryPointer)pointer;
            string singular = Inflector.Singularize(memPointer.Name);
            if (singular == memPointer.Name)
            {
                throw new InflectorException(
                    string.Format("Can not singularize \"{0}\". Use the AS keyword to specify singular identifier",
                        memPointer.Name), Cursor.Node);
            }

            DataType value = memPointer.Read();
            return CreatePlural(value, new IdentifierType(singular));
        }

        /// <summary>
        /// Creates a plural data type when singular name is provided.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.PluralID)]
        public DataType Plural(IdentifierType pSingular, DataType pData)
        {
            return CreatePlural(Resolve(pData), pSingular);
        }

        /// <summary>
        /// Decrement
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.PostDecrement)]
        public DataType PostDec(QualifiedType pId)
        {
            iVariablePointer pointer = Cursor.Resolve(pId);

            NumericType num = pointer.Read() as NumericType;
            if (num == null)
            {
                throw DataTypeException.InvalidTypes("--", pId);
            }

            num = num.isLong
                ? new NumericType(num.Long - 1)
                : new NumericType(num.Double - 1.0);

            pointer.Write(num);

            return num;
        }

        /// <summary>
        /// Increment
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.PostIncrement)]
        public DataType PostInc(QualifiedType pId)
        {
            iVariablePointer pointer = Cursor.Resolve(pId);

            NumericType num = pointer.Read() as NumericType;
            if (num == null)
            {
                throw DataTypeException.InvalidTypes("++", pId);
            }

            num = num.isLong
                ? new NumericType(num.Long + 1)
                : new NumericType(num.Double + 1.0);

            pointer.Write(num);

            return num;
        }

        /// <summary>
        /// Decrement
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.PreDecrement)]
        public DataType PreDec(QualifiedType pId)
        {
            iVariablePointer pointer = Cursor.Resolve(pId);

            NumericType num = pointer.Read() as NumericType;
            if (num == null)
            {
                throw DataTypeException.InvalidTypes("++", pId);
            }

            pointer.Write(num.isLong
                ? new NumericType(num.Long - 1)
                : new NumericType(num.Double - 1.0));

            return num;
        }

        /// <summary>
        /// Increment
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.PreIncrement)]
        public DataType PreInc(QualifiedType pId)
        {
            iVariablePointer pointer = Cursor.Resolve(pId);

            NumericType num = pointer.Read() as NumericType;
            if (num == null)
            {
                throw DataTypeException.InvalidTypes("++", pId);
            }

            pointer.Write(num.isLong
                ? new NumericType(num.Long + 1)
                : new NumericType(num.Double + 1.0));

            return num;
        }

        /// <summary>
        /// Returns the value of a variable.
        /// </summary>
        /// <param name="pId">The variable name</param>
        /// <returns>The value or undefined.</returns>
        [ExecuteSymbol(GrammarSymbol.QualifiedID)]
        public DataType Qualified(QualifiedType pId)
        {
            return Cursor.Resolve(pId).Read();
        }
    }
}