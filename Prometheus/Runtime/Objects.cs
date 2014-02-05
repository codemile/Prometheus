using System.Collections.Generic;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Parser.Executors;
using Prometheus.Parser.Executors.Attributes;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Handles grammar related to declaring objects.
    /// </summary>
    public class Objects : ExecutorGrammar
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Objects(Executor pExecutor)
            : base(pExecutor)
        {
        }

        /// <summary>
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.NewExpression)]
        public Data New(Data pIdentifier)
        {
            return New(pIdentifier, Data.Undefined);
        }

        /// <summary>
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.NewExpression)]
        public Data New(Data pIdentifier, Data pArguments)
        {
            try
            {
                Data obj = Executor.Cursor.Scope.Get(pIdentifier.getIdentifier().Name);
                //Node node = obj.getNode();
                //Dictionary<string, Data> variables = Arguments.CollectArguments(node, pArguments);

                return Executor.Execute(obj.getNode().Children[0], new Dictionary<string, Data>());
            }
            catch (ReturnException returnData)
            {
                return returnData.Value;
            }
        }

        /// <summary>
        /// Declares a new object type
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ObjectDecl)]
        public Data ObjectDeclare(Data pBaseType, Data pIdentifier)
        {
            Node obj = Executor.Cursor.Node;
            StaticType type = pBaseType.getStaticType();
            string id = pIdentifier.getIdentifier().Name;

            Executor.Cursor.Scope.Create(id, new Data(obj));

            return Data.Undefined;
        }
    }
}