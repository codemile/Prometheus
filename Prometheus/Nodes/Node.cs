using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Prometheus.Compile;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes.Types.Bases;

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
        public readonly List<DataType> Data;

        /// <summary>
        /// Where in the source code this node came from.
        /// </summary>
        public Location Location;

        /// <summary>
        /// The type of node.
        /// </summary>
        public GrammarSymbol Type;

        /// <summary>
        /// Does this node have a special handler.
        /// </summary>
        public int Handler { get; set; }

        /// <summary>
        /// Initializes a node.
        /// </summary>
        /// <param name="pType">The node's type.</param>
        /// <param name="pLocation">Location in the source code</param>
        public Node(GrammarSymbol pType, Location pLocation)
        {
            Handler = 0;
            Type = pType;
            Location = pLocation;
            Data = new List<DataType>();
            Children = new List<Node>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Node(GrammarSymbol pType, Location pLocation, IEnumerable<Node> pChildren)
            : this(pType, pLocation)
        {
            Children.AddRange(pChildren);
        }

        /// <summary>
        /// A statement that performs no operation.
        /// </summary>
        public static Node NoOp()
        {
            return new Node(GrammarSymbol.Statement, Location.None);
        }

        /// <summary>
        /// Sets this node to all the values of the other node.
        /// </summary>
        public void Set(Node pNode)
        {
#if DEBUG
            if (this == pNode)
            {
                throw new InvalidArgumentException("Cannot set node with itself",pNode);
            }
#endif

            Children.Clear();
            Data.Clear();

            Type = pNode.Type;
            Handler = pNode.Handler;
            Location = pNode.Location;
            Children.AddRange(pNode.Children);
            Data.AddRange(pNode.Data);
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

        /// <summary>
        /// Adds a node as a child.
        /// </summary>
        public Node Add(Node pChild)
        {
            Children.Add(pChild);
            return this;
        }

        /// <summary>
        /// Adds data to the node.
        /// </summary>
        public Node Add(DataType pData)
        {
            Data.Add(pData);
            return this;
        }

        /// <summary>
        /// Finds the first child of the given type, or returns Null.
        /// </summary>
        public Node FindChild(GrammarSymbol pSymbol)
        {
            return Children.FirstOrDefault(pNode=>pNode.Type == pSymbol);
        }

        /// <summary>
        /// Access the first child node.
        /// </summary>
        public Node FirstChild()
        {
            return Children[0];
        }

        /// <summary>
        /// Access the first data node.
        /// </summary>
        public DataType FirstData()
        {
            return Data[0];
        }

        /// <summary>
        /// Checks if this node has a child of a given symbol type.
        /// </summary>
        /// <param name="pSymbol">The symbol to check</param>
        /// <returns>True if found</returns>
        public bool HasChild(GrammarSymbol pSymbol)
        {
            return Children.Any(pChild=>pChild.Type == pSymbol);
        }

        /// <summary>
        /// Access the last child node.
        /// </summary>
        public Node LastChild()
        {
            return Children[Children.Count - 1];
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
        /// True if this node contains no data and no children.
        /// </summary>
        public bool IsEmpty()
        {
            return Children.Count == 0 && Data.Count == 0;
        }
    }
}