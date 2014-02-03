using Prometheus.Executors;
using Prometheus.Executors.Attributes;
using Prometheus.Grammar;
using Prometheus.Nodes.Types;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Holds a static value
    /// </summary>
    // ReSharper disable UnusedMember.Global
    public class ValueObject : ExecutorGrammar
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ValueObject(Executor pExecutor)
            : base(pExecutor)
        {
        }

        /// <summary>
        /// Returns the value of data stored in the source code.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.Value)]
        public Data Value(Data pValue)
        {
            return pValue;
        }
    }
}