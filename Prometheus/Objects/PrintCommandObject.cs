using System.Diagnostics;
using Prometheus.Nodes;

namespace Prometheus.Objects
{
    /// <summary>
    /// Prints a string to the output.
    /// </summary>
    public class PrintCommandObject : iPrometheusObject
    {
        /// <summary>
        /// Executes the statement
        /// </summary>
        /// <param name="pNode"></param>
        public void Execute(Node pNode)
        {
            Debug.WriteLine("PRINTING!!!!");
        }
    }
}