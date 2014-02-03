using System.Collections.Generic;
using System.Linq;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Parser;
using Prometheus.Runtime.Creators;

namespace Prometheus.Runtime
{
    /// <summary>
    /// </summary>
    public class Functions : PrometheusObject
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
        [SymbolHandler(GrammarSymbol.ArgumentList)]
        public Data Arguments()
        {
            return Data.Undefined;
        }

        /// <summary>
        /// Handles passing arguments to the call method.
        /// </summary>
        [SymbolHandler(GrammarSymbol.ArgumentList)]
        public Data Arguments(Data pArg1)
        {
            return new Data(new ArgumentList {pArg1});
        }

        /// <summary>
        /// Handles passing arguments to the call method.
        /// </summary>
        [SymbolHandler(GrammarSymbol.ArgumentList)]
        public Data Arguments(Data pArg1, Data pArg2)
        {
            return new Data(new ArgumentList {pArg1, pArg2});
        }

        /// <summary>
        /// Executes an identify as a function.
        /// </summary>
        /// <returns></returns>
        [SymbolHandler(GrammarSymbol.CallExpression)]
        public Data Call(Data pIndentifier)
        {
            return Call(pIndentifier, Data.Undefined);
        }

        /// <summary>
        /// Executes an identify as a function.
        /// </summary>
        /// <returns></returns>
        [SymbolHandler(GrammarSymbol.CallExpression)]
        public Data Call(Data pIndentifier, Data pArguments)
        {
            try
            {
                Node node = pIndentifier.getNode();
                int argCount = node.Data.Count;

                ArgumentList list = pArguments.getArgumentList();
                if (list.Count < argCount)
                {
                    list.AddRange(Enumerable.Repeat(Data.Undefined, argCount - list.Count));
                }

                Dictionary<string, Data> variables = new Dictionary<string, Data>(node.Data.Count);
                for (int i = 0; i < argCount; i++)
                {
                    variables.Add(node.Data[i].getIdentifier().Name, list[i]);
                }

                return Executor.Execute(node.Children[0], variables);
            }
            catch (ReturnException returnData)
            {
                return returnData.Value;
            }
        }

        /// <summary>
        /// Performs a return exception to break out of the function.
        /// </summary>
        [SymbolHandler(GrammarSymbol.ReturnProc)]
        public Data Return()
        {
            throw new ReturnException(Data.Undefined);
        }

        /// <summary>
        /// Performs a return exception to break out of the function.
        /// </summary>
        [SymbolHandler(GrammarSymbol.ReturnProc)]
        public Data Return(Data pData)
        {
            throw new ReturnException(pData);
        }
    }
}