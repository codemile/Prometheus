using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Prometheus.Compile;
using Prometheus.Grammar;

namespace Prometheus.Nodes
{
    /// <summary>
    /// Node in the tree of code.
    /// </summary>
    [DebuggerDisplay("{Type}")]
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
        public readonly Cursor Location;

        /// <summary>
        /// Initializes a node.
        /// </summary>
        /// <param name="pType">The node's type.</param>
        /// <param name="pLocation">Location in the source code</param>
        public Node(GrammarSymbol pType, Cursor pLocation)
        {
            Type = pType;
            Location = pLocation;
            Data = new List<Data>();
            Children = new List<Node>();
        }

        /// <summary>
        /// Call after removing any data or children by setting their
        /// entry in the list to null. This will remove those items.
        /// </summary>
        public void Reduce()
        {
            Children.RemoveAll(pChild=>pChild == null);
            Data.RemoveAll(pData=>pData == null);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return string.Format("'{0}' {1}", Type, Location);
        }
    }
}