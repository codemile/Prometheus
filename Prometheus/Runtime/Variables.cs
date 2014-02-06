using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Objects;
using Prometheus.Parser.Executors;
using Prometheus.Parser.Executors.Attributes;
using Prometheus.Properties;
using Prometheus.Storage;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Handles symbols related to variable management
    /// </summary>
    public class Variables : ExecutorGrammar
    {
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
        public Data Assignment(Data pQualified, Data pValue)
        {
            Executor.Cursor.Set(pQualified.getQualified(), pValue);
            return pValue;
        }

        /// <summary>
        /// Decrement
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.Decrement)]
        public Data Dec(Data pQualified)
        {
            Qualified id = pQualified.getQualified();
            string member = id.Parts[id.Parts.Length - 1];
            MemorySpace memory = Executor.Cursor.Resolve(id);
            Data d = memory.Get(member);
            d = d.Type == typeof (double)
                ? new Data(d.getPrecise() - 1)
                : new Data(d.getInteger() - 1);
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
        public Data Declare(Data pIdentifier, Data pValue)
        {
            Executor.Cursor.Stack.Create(pIdentifier.getIdentifier().Name, pValue);
            return pValue;
        }

        /// <summary>
        /// Declares a variable without a value
        /// </summary>
        /// <param name="pIdentifier">Name of the variable</param>
        /// <returns>The value assigned</returns>
        [ExecuteSymbol(GrammarSymbol.Declare)]
        public Data Declare(Data pIdentifier)
        {
            return Declare(pIdentifier, Data.Undefined);
        }

        /// <summary>
        /// Increment
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.Increment)]
        public Data Inc(Data pQualified)
        {
            Qualified id = pQualified.getQualified();
            string member = id.Parts[id.Parts.Length - 1];
            MemorySpace memory = Executor.Cursor.Resolve(id);
            Data d = memory.Get(member);
            d = d.Type == typeof (double)
                ? new Data(d.getPrecise() + 1)
                : new Data(d.getInteger() + 1);
            memory.Set(member, d);
            return d;
        }

        /// <summary>
        /// Decrement
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ListVars)]
        public Data ListVars()
        {
            Executor.Cursor.Stack.Print();
            return Data.Undefined;
        }

        /// <summary>
        /// Returns the value of data stored in the source code.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.Value)]
        public Data Value(Data pValue)
        {
            return pValue;
        }

        /// <summary>
        /// Returns the value of a variable.
        /// </summary>
        /// <param name="pQualifier">The variable name</param>
        /// <returns>The value or undefined.</returns>
        [ExecuteSymbol(GrammarSymbol.QualifiedID)]
        public Data Qualified(Data pQualifier)
        {
            return Executor.Cursor.Get(pQualifier.getQualified());
        }
    }
}