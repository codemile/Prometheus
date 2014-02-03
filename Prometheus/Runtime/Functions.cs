using System.Collections.Generic;
using System.Linq;
using Prometheus.Exceptions.Executor;
using Prometheus.Executors;
using Prometheus.Executors.Attributes;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;

namespace Prometheus.Runtime
{
    /// <summary>
    /// </summary>
    public class Functions : ExecutorGrammar
    {
        /// <summary>
        /// Collects the arguments for a function from the node.
        /// </summary>
        private static Dictionary<string, Data> CollectArguments(Node pNode, Data pArguments)
        {
            int argCount = pNode.Data.Count;

            ArgumentList list = pArguments.getArgumentList();
            if (list.Count < argCount)
            {
                list.AddRange(Enumerable.Repeat(Data.Undefined, argCount - list.Count));
            }

            Dictionary<string, Data> variables = new Dictionary<string, Data>(pNode.Data.Count);
            for (int i = 0; i < argCount; i++)
            {
                variables.Add(pNode.Data[i].getIdentifier().Name, list[i]);
            }
            return variables;
        }

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
        public Data Arguments()
        {
            return Data.Undefined;
        }

        /// <summary>
        /// Handles passing arguments to the call method.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ArgumentList)]
        public Data Arguments(Data pArg1)
        {
            return new Data(new ArgumentList {pArg1});
        }

        /// <summary>
        /// Handles passing arguments to the call method.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ArgumentList)]
        public Data Arguments(Data pArg1, Data pArg2)
        {
            return new Data(new ArgumentList {pArg1, pArg2});
        }

        /// <summary>
        /// Handles passing arguments to the call method.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ArgumentList)]
        public Data Arguments(Data pArg1, Data pArg2, Data pArg3)
        {
            return new Data(new ArgumentList {pArg1, pArg2, pArg3});
        }

        /// <summary>
        /// Handles passing arguments to the call method.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ArgumentList)]
        public Data Arguments(Data pArg1, Data pArg2, Data pArg3, Data pArg4)
        {
            return new Data(new ArgumentList {pArg1, pArg2, pArg3, pArg4});
        }

        /// <summary>
        /// Handles passing arguments to the call method.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ArgumentList)]
        public Data Arguments(Data pArg1, Data pArg2, Data pArg3, Data pArg4, Data pArg5)
        {
            return new Data(new ArgumentList {pArg1, pArg2, pArg3, pArg4, pArg5});
        }

        /// <summary>
        /// Handles passing arguments to the call method.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ArgumentList)]
        public Data Arguments(Data pArg1, Data pArg2, Data pArg3, Data pArg4, Data pArg5, Data pArg6)
        {
            return new Data(new ArgumentList {pArg1, pArg2, pArg3, pArg4, pArg5, pArg6});
        }

        /// <summary>
        /// Executes an identify as a function.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.CallExpression)]
        public Data Call(Data pFunction)
        {
            return Call(pFunction, Data.Undefined);
        }

        /// <summary>
        /// Executes an identify as a function.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.CallExpression)]
        public Data Call(Data pFunction, Data pArguments)
        {
            try
            {
                Node node = pFunction.getNode();
                Dictionary<string, Data> variables = CollectArguments(node, pArguments);

                return Executor.Execute(node.Children[0], variables);
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
        public Data CallInternal(Data pIdentifier, Data pArguments)
        {
            string name = pIdentifier.getIdentifier().Name;
            return Executor.Execute(name, pArguments.getArgumentList());
        }

        /// <summary>
        /// Performs a return exception to break out of the function.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ReturnProc)]
        public Data Return()
        {
            throw new ReturnException(Data.Undefined);
        }

        /// <summary>
        /// Performs a return exception to break out of the function.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ReturnProc)]
        public Data Return(Data pData)
        {
            throw new ReturnException(pData);
        }
    }
}