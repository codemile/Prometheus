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
            if (pValue.Type != typeof (Node))
            {
                return pValue;
            }
            Node func = pValue.getNode();
            if (func.Type != GrammarSymbol.FunctionExpression)
            {
                return pValue;
            }
            DataType _this = Executor.Cursor.Stack.Get("this");
            AliasType aThis = _this.getAlias();
            ClosureType closureType = new ClosureType(aThis, func);
            pValue = new DataType(closureType);
            return pValue;
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
        public DataType Assignment(DataType pQualified, DataType pValue)
        {
            pValue = CreateClosure(pValue);
            Executor.Cursor.Set(pQualified.getQualified(), pValue);
            return pValue;
        }

        /// <summary>
        /// Decrement
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.Decrement)]
        public DataType Dec(DataType pQualified)
        {
            QualifiedType id = pQualified.getQualified();
            string member = id.Parts[id.Parts.Length - 1];
            MemorySpace memory = Executor.Cursor.Resolve(id);
            DataType d = memory.Get(member);
            d = d.Type == typeof (double)
                ? new DataType(d.getPrecise() - 1)
                : new DataType(d.getInteger() - 1);
            memory.Set(member, d);
            return d;
        }

        /// <summary>
        /// Declares a variable with a value
        /// </summary>
        /// <param name="pIdentifier">Name of the variable</param>
        /// <param name="pValue">The value</param>
        /// <returns>The value assigned</returns>
        [ExecuteSymbol(GrammarSymbol.Declare)]
        public DataType Declare(DataType pIdentifier, DataType pValue)
        {
            pValue = CreateClosure(pValue);
            Executor.Cursor.Stack.Create(pIdentifier.getIdentifier().Name, pValue);
            return pValue;
        }

        /// <summary>
        /// Declares a variable without a value
        /// </summary>
        /// <param name="pIdentifier">Name of the variable</param>
        /// <returns>The value assigned</returns>
        [ExecuteSymbol(GrammarSymbol.Declare)]
        public DataType Declare(DataType pIdentifier)
        {
            return Declare(pIdentifier, DataType.Undefined);
        }

        /// <summary>
        /// Increment
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.Increment)]
        public DataType Inc(DataType pQualified)
        {
            QualifiedType id = pQualified.getQualified();
            string member = id.Parts[id.Parts.Length - 1];
            MemorySpace memory = Executor.Cursor.Resolve(id);
            DataType d = memory.Get(member);
            d = d.Type == typeof (double)
                ? new DataType(d.getPrecise() + 1)
                : new DataType(d.getInteger() + 1);
            memory.Set(member, d);
            return d;
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
        public DataType Qualified(DataType pQualifier)
        {
            return Executor.Cursor.Get(pQualifier.getQualified());
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