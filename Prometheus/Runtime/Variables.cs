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
        /// Will convert a function expression into a closure function with a reference
        /// to the current "this" object.
        /// </summary>
        private DataType CreateClosure(DataType pValue)
        {
            FunctionType func = pValue as FunctionType;
            if (func == null)
            {
                return pValue;
            }
            AliasType _this = (AliasType)Executor.Cursor.Stack.Get("this");
            return new ClosureType(_this, func.Func);
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
            MemorySpace memory = Executor.Cursor.Resolve(pQualified);
            DataType d = memory.Get(member);
            NumericType num = d as NumericType;
            if (num != null)
            {
                return num.Type == typeof(long) 
                    ? new NumericType(num.getLong()+1)
                    : new NumericType(num.getDouble()+1);
            }
            throw DataTypeException.InvalidTypes("++",d);
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
            return Declare(pIdentifier, DataType.Undefined);
        }

        /// <summary>
        /// Increment
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.Increment)]
        public DataType Inc(QualifiedType pQualified)
        {
            string member = pQualified.Parts[pQualified.Parts.Length - 1];
            MemorySpace memory = Executor.Cursor.Resolve(pQualified);
            DataType d = memory.Get(member);
            NumericType num = d as NumericType;
            if (num != null)
            {
                return num.Type == typeof(long)
                    ? new NumericType(num.getLong() - 1)
                    : new NumericType(num.getDouble() - 1);
            }
            throw DataTypeException.InvalidTypes("--", d);
        }

        /// <summary>
        /// Decrement
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ListVars)]
        public DataType ListVars()
        {
            Executor.Cursor.Stack.Print();
            return DataType.Undefined;
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
    }
}