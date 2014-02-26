using System;
using System.Collections.Generic;
using Prometheus.Compile;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Storage;

namespace Prometheus.Parser.Executors.Handlers
{
    /// <summary>
    /// Base class for node handlers.
    /// </summary>
    public abstract class ExecutorHandler : iExecutorHandler, iOptimizer
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
        [Obsolete]
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
        /// Filter what nodes this optimizer is executed for.
        /// </summary>
        public virtual bool Optimizable(GrammarSymbol pType)
        {
            return _nodeTypes.Contains(pType);
        }

        /// <summary>
        /// Called for each node in the tree. Implement this to
        /// modify just the node.
        /// </summary>
        /// <returns>True if tree was modified.</returns>
        public virtual bool OptimizeNode(Node pNode)
        {
            if (_nodeTypes.Contains(pNode.Symbol))
            {
                pNode.Handler = GetHandlerCode();
            }
            return false;
        }

        /// <summary>
        /// Inspect a node
        /// </summary>
        /// <param name="pParent"></param>
        /// <param name="pChild"></param>
        /// <returns>Same node, a new node or null to remove it.</returns>
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