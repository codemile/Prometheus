using Prometheus.Nodes;

namespace Prometheus.Compile.Optomizer
{
    /// <summary>
    /// A node trimmer will check if a node in the tree
    /// can be removed (along with it's children).
    /// </summary>
    public interface iNodeOptimizer
    {
        /// <summary>
        /// Inspect a node
        /// </summary>
        /// <param name="pNode">The node to check</param>
        /// <returns>Same node, a new node or null to remove it.</returns>
        Node Optomize(Node pNode);
    }
}