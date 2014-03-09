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
    // ReSharper disable UnusedParameter.Global
    // ReSharper disable UnusedMember.Global
    // ReSharper disable MemberCanBePrivate.Global
    // ReSharper disable ClassNeverInstantiated.Global
    public class Variables : ExecutorGrammar
    {
        /// <summary>
        /// Creates a plural data type object.
        /// </summary>
        private static DataType CreatePlural(Node pNode, DataType pValue, IdentifierType pSingular)
        {
            ArrayType arr = pValue as ArrayType;
            if (arr == null)
            {
                throw new InvalidArgumentException(
                    string.Format("Expected array value but found <{0}> instead", pValue.GetType().Name), pNode);
            }

            return new PluralType(arr, pSingular);
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
        [ExecuteSymbol(GrammarSymbol.Assignment)]
        public DataType Assignment(Node pNode, QualifiedType pId, DataType pValue)
        {
            DataType value = Resolve(pValue);
            Cursor.Resolve(pId).Write(value);
            return value;
        }

        /// <summary>
        /// Declares a variable with a value
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.Declare)]
        public DataType Declare(Node pNode, IdentifierType pIdentifier, DataType pValue)
        {
            pValue = Resolve(pValue);
            Cursor.Stack.Create(pIdentifier.Name, pValue);
            return pValue;
        }

        /// <summary>
        /// Declares a variable without a value
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.Declare)]
        public DataType Declare(Node pNode, IdentifierType pIdentifier)
        {
            return Declare(pNode, pIdentifier, UndefinedType.Undefined);
        }

        /// <summary>
        /// Checks if the qualifier ID is valid.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.IssetFunc)]
        public DataType Isset(Node pNode, QualifiedType pId)
        {
            iVariablePointer pointer = Cursor.Resolve(pId);
            return new BooleanType(pointer.IsValid());
        }

        /// <summary>
        /// Creates a singular identifier from a reference to a plural identifier.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.PluralID)]
        public DataType Plural(Node pNode, QualifiedType pId)
        {
            iVariablePointer pointer = Cursor.Resolve(pId);
            if (pointer is ArrayPointer)
            {
                throw new InvalidArgumentException(
                    "Can not singularize an array identifier. Use the AS keyword to specify singular identifier",
                    pNode);
            }
#if DEBUG
            if (!(pointer is MemoryPointer))
            {
                throw new UnexpectedErrorException("Pointer is of unexpected type", pNode);
            }
#endif
            MemoryPointer memPointer = (MemoryPointer)pointer;
            string singular = Inflector.Singularize(memPointer.Name);
            if (singular == memPointer.Name)
            {
                throw new InflectorException(
                    string.Format("Can not singularize \"{0}\". Use the AS keyword to specify singular identifier",
                        memPointer.Name), pNode);
            }

            DataType value = memPointer.Read();
            return CreatePlural(pNode, value, new IdentifierType(singular));
        }

        /// <summary>
        /// Creates a plural data type when singular name is provided.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.PluralID)]
        public DataType Plural(Node pNode, IdentifierType pSingular, DataType pData)
        {
            return CreatePlural(pNode, Resolve(pData), pSingular);
        }

        /// <summary>
        /// Decrement
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.PostDecrement)]
        public DataType PostDec(Node pNode, QualifiedType pId)
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
        public DataType PostInc(Node pNode, QualifiedType pId)
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
        public DataType PreDec(Node pNode, QualifiedType pId)
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
        public DataType PreInc(Node pNode, QualifiedType pId)
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
        [ExecuteSymbol(GrammarSymbol.QualifiedID)]
        public DataType Qualified(Node pNode, QualifiedType pId)
        {
            return Cursor.Resolve(pId).Read();
        }
    }
}