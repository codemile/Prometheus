using System.Collections.Generic;
using System.Diagnostics;
using Prometheus.Compile;
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
        /// The data for this node.
        /// </summary>
        public readonly List<Data> Data;

        /// <summary>
        /// The type of node.
        /// </summary>
        public readonly GrammarSymbol Type;

        /// <summary>
        /// Where in the source code this node came from.
        /// </summary>
        private readonly Cursor _location;

        /// <summary>
        /// Initializes a node.
        /// </summary>
        /// <param name="pType">The node's type.</param>
        /// <param name="pLocation">Location in the source code</param>
        public Node(GrammarSymbol pType, Cursor pLocation)
        {
            Type = pType;
            _location = pLocation;
            Data = new List<Data>();
            Children = new List<Node>();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0} in {1}", Type, _location);
        }
    }
}