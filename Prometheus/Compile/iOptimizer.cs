using Prometheus.Grammar;
using Prometheus.Nodes;

namespace Prometheus.Compile
{
    /// <summary>
    /// A node trimmer will check if a node in the tree
    /// can be removed (along with it's children).
    /// </summary>
    public interface iOptimizer
    {
        /// <summary>
        /// Filter what nodes this optimizer is executed for.
        /// </summary>
        bool Optimizable(GrammarSymbol pType);

        /// <summary>
        /// Called for each node in the tree. Implement this to
        /// modify just the node.
        /// </summary>
        /// <returns>True if tree was modified.</returns>
        bool OptimizeNode(Node pNode);

        /// <summary>
        /// Called when a child node matches the handled type. Implement this to
        /// modify the parent to child relationship.
        /// </summary>
        /// <returns>True if tree was modified.</returns>
        bool OptimizeChild(Node pParent, Node pChild);

        /// <summary>
        /// Called when a parent node matches the handled type. Implement this to
        /// modify the parent to child relationship.
        /// </summary>
        /// <returns>True if tree was modified.</returns>
        bool OptimizeParent(Node pParent, Node pChild);

        /// <summary>
        /// Inspect a node after optimization has finished. This method
        /// is called only once per node.
        /// </summary>
        void OptimizePost(Node pNode);
    }
}