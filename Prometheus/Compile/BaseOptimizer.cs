using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Parser.Executors;

namespace Prometheus.Compile
{
    /// <summary>
    /// Convenience class for iOptimier implementations.
    /// </summary>
    public abstract class BaseOptimizer : iOptimizer
    {
        /// <summary>
        /// The current executor.
        /// </summary>
        protected readonly iExecutor Executor;

        /// <summary>
        /// The node types.
        /// </summary>
        protected readonly HashSet<GrammarSymbol> NodeTypes;

        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseOptimizer(iExecutor pExecutor, HashSet<GrammarSymbol> pNodeTypes)
        {
            Executor = pExecutor;
            NodeTypes = pNodeTypes;
        }

        /// <summary>
        /// Filter what nodes this optimizer is executed for.
        /// </summary>
        public virtual bool Optimizable(GrammarSymbol pType)
        {
            return NodeTypes.Contains(pType);
        }

        /// <summary>
        /// Called for each node in the tree. Implement this to
        /// modify just the node.
        /// </summary>
        /// <returns>True if tree was modified.</returns>
        public virtual bool OptimizeNode(Node pNode)
        {
            return false;
        }

        /// <summary>
        /// Called when a child node matches the handled type. Implement this to
        /// modify the parent to child relationship.
        /// </summary>
        /// <returns>True if tree was modified.</returns>
        public virtual bool OptimizeChild(Node pParent, Node pChild)
        {
            return false;
        }

        /// <summary>
        /// Called when a parent node matches the handled type. Implement this to
        /// modify the parent to child relationship.
        /// </summary>
        /// <returns>True if tree was modified.</returns>
        public virtual bool OptimizeParent(Node pParent, Node pChild)
        {
            return false;
        }

        /// <summary>
        /// Inspect a node after optimization has finished. This method
        /// is called only once per node.
        /// </summary>
        public virtual void OptimizePost(Node pNode)
        {
        }
    }
}