using Prometheus.Grammar;
using Prometheus.Nodes;

namespace Prometheus.Compile.Optomizer
{
    /// <summary>
    /// Drop nodes where their child count and data count match.
    /// </summary>
    public class DropByCount : iNodeOptimizer
    {
        /// <summary>
        /// Child count to match
        /// </summary>
        private readonly int _childCount;

        /// <summary>
        /// Data count to match
        /// </summary>
        private readonly int _dataCount;

        /// <summary>
        /// The symbol to match.
        /// </summary>
        private readonly GrammarSymbol _symbol;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pSymbol">The symbol</param>
        /// <param name="pChildCount">The number of children</param>
        /// <param name="pDataCount">The number of data elements</param>
        public DropByCount(GrammarSymbol pSymbol, int pChildCount, int pDataCount)
        {
            _symbol = pSymbol;
            _childCount = pChildCount;
            _dataCount = pDataCount;
        }

        /// <summary>
        /// True if this node can be removed from the node tree.
        /// </summary>
        /// <param name="pNode">The node to check</param>
        /// <returns>True to trim the node.</returns>
        public Node Optomize(Node pNode)
        {
            return (pNode.Type == _symbol &&
                    pNode.Children.Count == _childCount &&
                    pNode.Data.Count == _dataCount)
                ? null
                : pNode;
        }
    }
}