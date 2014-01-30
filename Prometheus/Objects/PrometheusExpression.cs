using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prometheus.Grammar;
using Prometheus.Nodes;

namespace Prometheus.Objects
{
    /// <summary>
    /// Represents an executable object that evaluates a result.
    /// </summary>
    public abstract class PrometheusExpression : PrometheusObject
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pObjects">The grammar objects</param>
        protected PrometheusExpression(GrammarObject pObjects) 
            : base(pObjects)
        {
        }

        /// <summary>
        /// Evaluate the node for a string result.
        /// </summary>
        /// <param name="pNode">The node expression.</param>
        /// <returns>The string result</returns>
        public abstract string getString(Node pNode);
    }
}
