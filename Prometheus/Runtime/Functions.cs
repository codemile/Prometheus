using System.Collections.Generic;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Objects;
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
        /// Handles passing arguments to the call method.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ArgumentList)]
        public DataType Arguments()
        {
            return DataType.Undefined;
        }

        /// <summary>
        /// Handles passing arguments to the call method.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ArgumentList)]
        public DataType Arguments(DataType pArg1)
        {
            return new DataType(new ArgumentListType {pArg1});
        }

        /// <summary>
        /// Handles passing arguments to the call method.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ArgumentList)]
        public DataType Arguments(DataType pArg1, DataType pArg2)
        {
            return new DataType(new ArgumentListType {pArg1, pArg2});
        }

        /// <summary>
        /// Handles passing arguments to the call method.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ArgumentList)]
        public DataType Arguments(DataType pArg1, DataType pArg2, DataType pArg3)
        {
            return new DataType(new ArgumentListType {pArg1, pArg2, pArg3});
        }

        /// <summary>
        /// Handles passing arguments to the call method.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ArgumentList)]
        public DataType Arguments(DataType pArg1, DataType pArg2, DataType pArg3, DataType pArg4)
        {
            return new DataType(new ArgumentListType {pArg1, pArg2, pArg3, pArg4});
        }

        /// <summary>
        /// Handles passing arguments to the call method.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ArgumentList)]
        public DataType Arguments(DataType pArg1, DataType pArg2, DataType pArg3, DataType pArg4, DataType pArg5)
        {
            return new DataType(new ArgumentListType {pArg1, pArg2, pArg3, pArg4, pArg5});
        }

        /// <summary>
        /// Handles passing arguments to the call method.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ArgumentList)]
        public DataType Arguments(DataType pArg1, DataType pArg2, DataType pArg3, DataType pArg4, DataType pArg5, DataType pArg6)
        {
            return new DataType(new ArgumentListType {pArg1, pArg2, pArg3, pArg4, pArg5, pArg6});
        }

        /// <summary>
        /// Executes an identify as a function.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.CallExpression)]
        public DataType Call(DataType pClosure)
        {
            return Call(pClosure, DataType.Undefined);
        }

        /// <summary>
        /// Executes a closure a function.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.CallExpression)]
        public DataType Call(DataType pClosure, DataType pArguments)
        {
            try
            {
                // calling base constructor
                if (pClosure.Type == typeof (AliasType))
                {
                    AliasType a = pClosure.getAlias();
                    Instance inst = Executor.Cursor.Heap.Get(a);
                    Dictionary<string, DataType> variables = Runtime.Arguments.CollectArguments(inst.Constructor, pArguments);
                    return Executor.Execute(inst.Constructor, variables);
                }
                else
                {
                    ClosureType closureType = pClosure.getClosure();
                    // empty function check
                    if (closureType.Function.Children.Count == 0)
                    {
                        return DataType.Undefined;
                    }
                    Dictionary<string, DataType> variables = Runtime.Arguments.CollectArguments(closureType.Function, pArguments);
                    variables.Add("this", closureType.This);
                    return Executor.Execute(closureType.Function.Children[0], variables);
                }
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
        public DataType CallInternal(DataType pIdentifier, DataType pArguments)
        {
            string name = pIdentifier.getIdentifier().Name;
            return Executor.Execute(name, pArguments.getArgumentList());
        }

        /// <summary>
        /// Performs a return exception to break out of the function.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ReturnProc)]
        public DataType Return()
        {
            throw new ReturnException(DataType.Undefined);
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