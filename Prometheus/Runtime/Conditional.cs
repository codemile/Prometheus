using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Parser.Executors;
using Prometheus.Parser.Executors.Attributes;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Handles conditional execution of blocks of code.
    /// </summary>
    // ReSharper disable UnusedParameter.Global
    // ReSharper disable UnusedMember.Global
    // ReSharper disable MemberCanBePrivate.Global
    // ReSharper disable ClassNeverInstantiated.Global
    public class Conditional : ExecutorGrammar
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Conditional(Executor pExecutor)
            : base(pExecutor)
        {
        }

        /// <summary>
        /// Execute a block if condition is true.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.IfControl)]
        public DataType IfThen(Node pNode, DataType pCondition, FunctionType pThen)
        {
            DataType value = Resolve(pCondition);
            return value.getBool()
                ? Executor.Execute(pThen)
                : UndefinedType.Undefined;
        }

        /// <summary>
        /// Execute a block if condition is true.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.IfControl)]
        public DataType IfThenElse(Node pNode, DataType pCondition, FunctionType pThen, FunctionType pElse)
        {
            DataType value = Resolve(pCondition);
            return value.getBool()
                ? Executor.Execute(pThen)
                : Executor.Execute(pElse);
        }
    }
}