using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Parser.Executors;
using Prometheus.Parser.Executors.Attributes;
using Prometheus.Storage;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Handles symbols related to variable management
    /// </summary>
    // ReSharper disable UnusedParameter.Global
    // ReSharper disable UnusedMember.Global
    // ReSharper disable MemberCanBePrivate.Global
    // ReSharper disable ClassNeverInstantiated.Global
    public class Dump : ExecutorGrammar
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Dump(Executor pExecutor)
            : base(pExecutor)
        {
        }

        /// <summary>
        /// Decrement
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ListVars)]
        public UndefinedType Vars(Node pNode)
        {
            StorageDump handler = new StorageDump();
            handler.Dump(Cursor.Stack.Dump());

            return UndefinedType.Undefined;
        }
    }
}