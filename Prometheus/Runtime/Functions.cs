using System.Collections.Generic;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Parser.Executors;
using Prometheus.Parser.Executors.Attributes;

namespace Prometheus.Runtime
{
    /// <summary>
    /// </summary>
    public class Functions : ExecutorGrammar
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Functions(Executor pExecutor)
            : base(pExecutor)
        {
        }

        /// <summary>
        /// Declares a new function type
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.FunctionDecl)]
        public DataType FunctionDeclare(IdentifierType pFuncName, ClosureType pFunc)
        {
            Executor.Cursor.Stack.Create(pFuncName.Name, pFunc);
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Declares a new function type
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.FunctionDecl)]
        public DataType FunctionDeclare(IdentifierType pFuncName, IEnumerable<DataType> pParameters, ClosureType pFunc)
        {
            Executor.Cursor.Stack.Create(pFuncName.Name, new ClosureType(pFunc.Function, pParameters));
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Executes an identify as a function.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.CallExpression)]
        public DataType Call(QualifiedType pId)
        {
            return Call(pId, ArrayType.Empty);
        }

        /// <summary>
        /// Executes a closure a function.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.CallExpression)]
        public DataType Call(QualifiedType pId, ArrayType pArguments)
        {
            try
            {
                ClosureType func = Executor.Cursor.Get<ClosureType>(pId);
                // empty function check
                if (func.Function.Children.Count == 0)
                {
                    return UndefinedType.Undefined;
                }
                // resolve the argument
                DataType[] arguments = new DataType[pArguments.Count];
                for(int i=0, c = arguments.Length; i < c; i++)
                {
                    arguments[i] = Resolve(pArguments[i]);
                }
                // call the function
                return Executor.Execute(func.Function, func.CreateArguments(arguments));
            }
            catch (ReturnException returnData)
            {
                return returnData.Value;
            }
        }

        /// <summary>
        /// Executes an internal function.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.CallInternal)]
        public DataType CallInternal(IdentifierType pIdentifier, ArrayType pArguments)
        {
            string name = pIdentifier.Name;
            return Executor.Execute(name, pArguments.Values);
        }

        /// <summary>
        /// Performs a return exception to break out of the function.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ReturnProc)]
        public DataType Return()
        {
            throw new ReturnException(UndefinedType.Undefined);
        }

        /// <summary>
        /// Performs a return exception to break out of the function.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ReturnProc)]
        public DataType Return(DataType pDataType)
        {
            throw new ReturnException(pDataType);
        }
    }
}