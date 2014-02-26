using System.Collections.Generic;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Parser.Executors
{
    /// <summary>
    /// Handles processing the node tree.
    /// </summary>
    public interface iExecutor
    {
        /// <summary>
        /// Executes a node with predefined variables.
        /// </summary>
        DataType Execute(Node pNode, Dictionary<string, DataType> pVariables = null);

        /// <summary>
        /// Executes a function reference.
        /// </summary>
        DataType Execute(FunctionType pBlock, Dictionary<string, DataType> pVariables = null);

        /// <summary>
        /// Executes a function reference, but catches a ContinueException
        /// and returns normally.
        /// </summary>
        DataType ExecuteContinuable(FunctionType pBlock, Dictionary<string, DataType> pVariables = null);

        /// <summary>
        /// The current position in the node tree.
        /// </summary>
        Cursor GetCursor();

        /// <summary>
        /// Processes a branch of the node tree.
        /// </summary>
        DataType WalkDownChildren(Node pNode);
    }
}