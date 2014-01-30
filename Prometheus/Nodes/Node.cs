using System.Collections.Generic;
using System.Diagnostics;
using Prometheus.Grammar;

namespace Prometheus.Nodes
{
    /// <summary>
    /// Node in the tree of code.
    /// </summary>
    [DebuggerDisplay("{Symbol}")]
    public class Node
    {
        /// <summary>
        /// The children of this node.
        /// </summary>
        public readonly List<Node> Children;

        /// <summary>
        /// The column position
        /// </summary>
        public readonly int Column;

        /// <summary>
        /// The data for this node.
        /// </summary>
        public readonly List<Data> Data;

        /// <summary>
        /// The line position
        /// </summary>
        public readonly int Row;

        /// <summary>
        /// Reference to the source file.
        /// </summary>
        public readonly int Source;

        /// <summary>
        /// The type of node.
        /// </summary>
        public readonly GrammarSymbol Type;

        /// <summary>
        /// Initializes a node.
        /// </summary>
        /// <param name="pType">The node's type.</param>
        /// <param name="pSource">The source file.</param>
        /// <param name="pRow">The line number</param>
        /// <param name="pColumn">The column position</param>
        public Node(GrammarSymbol pType, int pSource, int pRow, int pColumn)
        {
            Type = pType;
            Source = pSource;
            Row = pRow;
            Column = pColumn;
            Data = new List<Data>();
            Children = new List<Node>();
        }
    }
}