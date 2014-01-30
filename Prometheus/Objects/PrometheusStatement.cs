using Prometheus.Grammar;
using Prometheus.Nodes;

namespace Prometheus.Objects
{
    /// <summary>
    /// Represents an object that is executable as a statement.
    /// </summary>
    public abstract class PrometheusStatement : PrometheusObject
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pObjects">The grammar objects</param>
        protected PrometheusStatement(GrammarObject pObjects) 
            : base(pObjects)
        {
        }

        /// <summary>
        /// Executes the statement
        /// </summary>
        /// <param name="pNode"></param>
        public abstract void Execute(Node pNode);
    }
}