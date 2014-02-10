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
        public iDataType Arguments()
        {
            return UndefinedType.UNDEFINED;
        }

        /// <summary>
        /// Handles passing arguments to the call method.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ArgumentList)]
        public ArgumentListType Arguments(iDataType pArg1)
        {
            return new ArgumentListType(new[] {pArg1});
        }

        /// <summary>
        /// Handles passing arguments to the call method.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ArgumentList)]
        public ArgumentListType Arguments(iDataType pArg1, iDataType pArg2)
        {
            return new ArgumentListType(new[] {pArg1, pArg2});
        }

        /// <summary>
        /// Handles passing arguments to the call method.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ArgumentList)]
        public ArgumentListType Arguments(iDataType pArg1, iDataType pArg2, iDataType pArg3)
        {
            return new ArgumentListType(new[] {pArg1, pArg2, pArg3});
        }

        /// <summary>
        /// Handles passing arguments to the call method.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ArgumentList)]
        public ArgumentListType Arguments(iDataType pArg1, iDataType pArg2, iDataType pArg3, iDataType pArg4)
        {
            return new ArgumentListType(new[] {pArg1, pArg2, pArg3, pArg4});
        }

        /// <summary>
        /// Handles passing arguments to the call method.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ArgumentList)]
        public ArgumentListType Arguments(iDataType pArg1, iDataType pArg2, iDataType pArg3, iDataType pArg4, iDataType pArg5)
        {
            return new ArgumentListType(new[] {pArg1, pArg2, pArg3, pArg4, pArg5});
        }

        /// <summary>
        /// Handles passing arguments to the call method.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ArgumentList)]
        public ArgumentListType Arguments(iDataType pArg1, iDataType pArg2, iDataType pArg3, iDataType pArg4, iDataType pArg5,
                                          iDataType pArg6)
        {
            return new ArgumentListType(new[] {pArg1, pArg2, pArg3, pArg4, pArg5, pArg6});
        }

        /// <summary>
        /// Executes a closure a function.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.CallExpression)]
        public iDataType Call(AliasType pAliasType, ArgumentListType pArguments = null)
        {
            try
            {
                Instance inst = Executor.Cursor.Heap.Get(pAliasType);
                Dictionary<string, iDataType> variables = Runtime.Arguments.CollectArguments(inst.Constructor, pArguments);
                return Executor.Execute(inst.Constructor, variables);
            }
            catch (ReturnException returnData)
            {
                return returnData.Value;
            }
        }

        /// <summary>
        /// Executes a closure a function.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.CallExpression)]
        public iDataType Call(ClosureType pClosureType, ArgumentListType pArguments = null)
        {
            try
            {
                // empty function check
                if (pClosureType.Function.Children.Count == 0)
                {
                    return UndefinedType.UNDEFINED;
                }
                Dictionary<string, iDataType> variables = Runtime.Arguments.CollectArguments(pClosureType.Function,
                    pArguments);
                variables.Add("this", pClosureType.This);
                return Executor.Execute(pClosureType.Function.Children[0], variables);
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
        public iDataType CallInternal(IdentifierType pIdentifierType, ArgumentListType pArguments)
        {
            string name = pIdentifierType.Name;
            return Executor.Execute(name, pArguments.Arguments);
        }

        /// <summary>
        /// Performs a return exception to break out of the function.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ReturnProc)]
        public iDataType Return()
        {
            throw new ReturnException(UndefinedType.UNDEFINED);
        }

        /// <summary>
        /// Performs a return exception to break out of the function.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ReturnProc)]
        public iDataType Return(iDataType pDataType)
        {
            throw new ReturnException(pDataType);
        }
    }
}