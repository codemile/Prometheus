using System;
using Prometheus.Grammar;
using Prometheus.Nodes;

namespace Prometheus.Objects
{
    /// <summary>
    /// Holds a static value
    /// </summary>
    public class ValueObject : PrometheusExpression
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pObjects">The grammar objects</param>
        public ValueObject(GrammarObject pObjects) 
            : base(pObjects)
        {
        }

        /// <summary>
        /// Evaluate the node for a string result.
        /// </summary>
        /// <param name="pNode">The node expression.</param>
        /// <returns>The string result</returns>
        public override string getString(Node pNode)
        {
            return pNode.Data[0].Value;
        }
    }
}