using System.Collections.Generic;
using Prometheus.Compile.Optimizers;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Storage;

namespace Prometheus.Parser.Executors.Handlers
{
    /// <summary>
    /// Base class for node handlers.
    /// </summary>
    public abstract class ExecutorHandler : iExecutorHandler, iNodeOptimizer
    {
        /// <summary>
        /// The cursor
        /// </summary>
        protected readonly Cursor Cursor;

        /// <summary>
        /// The executor
        /// </summary>
        protected readonly iExecutor Executor;

        /// <summary>
        /// The node types processed by this handler.
        /// </summary>
        private readonly HashSet<GrammarSymbol> _nodeTypes;

        /// <summary>
        /// Constructor
        /// </summary>
        protected ExecutorHandler(iExecutor pExecutor, HashSet<GrammarSymbol> pTypes)
        {
            _nodeTypes = pTypes;

            Executor = pExecutor;
            Cursor = pExecutor.GetCursor();
        }

        /// <summary>
        /// Executes the block for an inner loop. Creating the stack
        /// space required for the loop, and handling a continue
        /// exception.
        /// </summary>
        protected void ExecuteBlock(Node pBlock, Dictionary<string, DataType> pVariables = null)
        {
            using (Cursor.Stack = new CursorSpace(Cursor, pVariables ?? new Dictionary<string, DataType>()))
            {
                try
                {
                    Executor.WalkDownChildren(pBlock);
                }
                catch (ContinueException)
                {
                }
            }
        }

        /// <summary>
        /// Executes only the children of a node.
        /// </summary>
        protected void ExecuteChildren(Node pNode)
        {
            for (int i = 0, c = pNode.Children.Count; i < c; i++)
            {
                Executor.WalkDownChildren(pNode.Children[i]);
            }
        }

        /// <summary>
        /// True if handler processes this node.
        /// </summary>
        public bool CanHandleNode(Node pNode)
        {
            return _nodeTypes.Contains(pNode.Type);
        }

        /// <summary>
        /// Handle execution of a node.
        /// </summary>
        public abstract DataType Handle(Node pNode);

        /// <summary>
        /// The unique ID of the handler.
        /// </summary>
        public int GetHandlerCode()
        {
            return GetType().Name.GetHashCode();
        }

        /// <summary>
        /// Inspect a node
        /// </summary>
        /// <param name="pNode">The node to check</param>
        /// <returns>Same node, a new node or null to remove it.</returns>
        public virtual Node Optimize(Node pNode)
        {
            if (_nodeTypes.Contains(pNode.Type))
            {
                pNode.Handler = GetHandlerCode();
            }
            return pNode;
        }
    }
}