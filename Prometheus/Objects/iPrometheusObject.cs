using Prometheus.Nodes;

namespace Prometheus.Objects
{
    /// <summary>
    /// Interface for all commands.
    /// </summary>
    public interface iPrometheusObject
    {
        /// <summary>
        /// Executes the statement
        /// </summary>
        /// <param name="pNode"></param>
        void Execute(Node pNode);
    }
}