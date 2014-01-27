using System.Collections.Generic;
using System.Diagnostics;

namespace Prometheus
{
    /// <summary>
    /// Node in the tree of code.
    /// </summary>
    [DebuggerDisplay("{Symbol}")]
    public class Node
    {
        /// <summary>
        /// The type of node.
        /// </summary>
        public readonly ParserSymbol Symbol;

        /// <summary>
        /// The data for this node.
        /// </summary>
        public readonly List<Data> Data;

        /// <summary>
        /// The children of this node.
        /// </summary>
        public readonly List<Node> Children;

        /// <summary>
        /// </summary>
        /// <param name="pSymbol"></param>
        public Node(ParserSymbol pSymbol)
        {
            Symbol = pSymbol;
            Data = new List<Data>();
            Children = new List<Node>();
        }
    }
}