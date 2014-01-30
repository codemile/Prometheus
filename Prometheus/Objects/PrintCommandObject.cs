using System.Diagnostics;
using Prometheus.Grammar;
using Prometheus.Nodes;

namespace Prometheus.Objects
{
    /// <summary>
    /// Prints a string to the output.
    /// </summary>
    public class PrintCommandObject : PrometheusStatement
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pObjects">The grammar objects</param>
        public PrintCommandObject(GrammarObject pObjects) 
            : base(pObjects)
        {
        }

        /// <summary>
        /// Executes the statement
        /// </summary>
        /// <param name="pNode"></param>
        public override void Execute(Node pNode)
        {
            PrometheusExpression expression = getExpression(pNode.Children[0]);
            Debug.WriteLine(expression.getString(pNode.Children[0]));
        }
    }
}