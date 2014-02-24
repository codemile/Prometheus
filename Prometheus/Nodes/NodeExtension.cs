using System.Collections.Generic;

namespace Prometheus.Nodes
{
    /// <summary>
    /// Extension methods for managing nodes.
    /// </summary>
    public static class NodeExtension
    {
        /// <summary>
        /// Inserts a collection of nodes at a given location.
        /// </summary>
        public static List<Node> InsertRange(this List<Node> pChildren, int pIndex, IList<Node> pNodes)
        {
            for (int i = pNodes.Count - 1; i >= 0; i--)
            {
                pChildren.Insert(pIndex, pNodes[i]);
            }
            return pChildren;
        }

        /// <summary>
        /// Replaces a single child with a collection of new children at that position.
        /// </summary>
        public static List<Node> ReplaceNode(this List<Node> pChildren, Node pChild, IEnumerable<Node> pThese)
        {
            int where = pChildren.IndexOf(pChild);
            pChildren.Remove(pChild);
            pChildren.InsertRange(where, pThese);
            return pChildren;
        }
    }
}