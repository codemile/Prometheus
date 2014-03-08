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
    /// </summary>
    // ReSharper disable UnusedParameter.Global
    // ReSharper disable UnusedMember.Global
    // ReSharper disable MemberCanBePrivate.Global
    // ReSharper disable ClassNeverInstantiated.Global
    public class FunctionCalling : ExecutorGrammar
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FunctionCalling(Executor pExecutor)
            : base(pExecutor)
        {
        }

        /// <summary>
        /// Executes an identify as a function.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.CallExpression)]
        public DataType Call(Node pNode, QualifiedType pId)
        {
            return Call(pNode, pId, ArrayType.Empty);
        }

        /// <summary>
        /// Executes a closure a function.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.CallExpression)]
        public DataType Call(Node pNode, QualifiedType pId, ArrayType pArguments)
        {
            try
            {
                ClosureType func = Cursor.Get<ClosureType>(pId);
                // empty function check
                if (func.Function.Entry.Children.Count == 0)
                {
                    return UndefinedType.Undefined;
                }
                // resolve the arguments
                DataType[] arguments = new DataType[pArguments.Count];
                for (int i = 0, c = arguments.Length; i < c; i++)
                {
                    arguments[i] = Resolve(pArguments[i]);
                }
                // call the function
                return Executor.Execute(func.Function.Entry, func.CreateArguments(arguments));
            }
            catch (ReturnException returnData)
            {
                return returnData.Value;
            }
        }

        /// <summary>
        /// Performs a return exception to break out of the function.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ReturnProc)]
        public DataType Return(Node pNode)
        {
            throw new ReturnException(UndefinedType.Undefined, pNode);
        }

        /// <summary>
        /// Performs a return exception to break out of the function.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ReturnProc)]
        public DataType Return(Node pNode, DataType pDataType)
        {
            throw new ReturnException(Resolve(pDataType), pNode);
        }
    }
}