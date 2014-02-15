using System;
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
        /// Executes an identify as a function.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.CallExpression)]
        public DataType Call(DataType pClosure)
        {
/*
            return Call(pClosure, ArrayType.Empty);
*/
            throw new NotImplementedException();
        }

        /// <summary>
        /// Executes a closure a function.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.CallExpression)]
        public DataType Call(DataType pClosure, ArrayType pArguments)
        {
            throw new NotImplementedException();
            /*
                        try
                        {
                            // calling base constructor
                            if (pClosure.GetType() == typeof (AliasType))
                            {
                                AliasType a = (AliasType)pClosure;
                                Instance inst = Executor.Cursor.Heap.Get(a);
                                Dictionary<string, DataType> variables = Arguments.CollectArguments(inst.GetConstructor(),
                                    pArguments);
                                return Executor.Execute(inst.GetConstructor(), variables);
                            }
                            else
                            {
                                ClosureType closureType = (ClosureType)pClosure;
                                // empty function check
                                if (closureType.Function.Children.Count == 0)
                                {
                                    return UndefinedType.Undefined;
                                }
                                Dictionary<string, DataType> variables = Arguments.CollectArguments(closureType.Function,
                                    pArguments);
                                variables.Add("this", closureType.This);
                                return Executor.Execute(closureType.Function.Children[0], variables);
                            }
                        }
                        catch (ReturnException returnData)
                        {
                            return returnData.Value;
                        }
            */
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