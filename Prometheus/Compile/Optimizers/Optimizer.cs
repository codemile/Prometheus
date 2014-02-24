using System.Collections.Generic;
using System.Linq;
using Prometheus.Exceptions;
using Prometheus.Nodes;
using Prometheus.Parser;
using Prometheus.Parser.Executors;

namespace Prometheus.Compile.Optimizers
{
    /// <summary>
    /// Optimizes a compiled node tree. This code is constantly modified to as grammar rules are changed in the parser, but the
    /// general idea for optimizing is two things. First, to reduce the number of nodes in the tree. Second, to change nodes
    /// to make work for the parser easier.
    /// </summary>
    public class Optimizer
    {
        /// <summary>
        /// The current node being optimized.
        /// </summary>
        private Cursor _cursor;

        /// <summary>
        /// Used to perform optimization
        /// </summary>
        private Executor _executor;

        /// <summary>
        /// Objects that handle optimization of nodes.
        /// </summary>
        private List<iOptimizer> _optimizers;


        /// <summary>
        /// Optimizes a node and it's children.
        /// </summary>
        /// <param name="pNode">The node to work on.</param>
        /// <returns>True if the tree has been modified</returns>
        private bool OptimizeNode(Node pNode)
        {
            _cursor.Node = pNode;

            if (_optimizers
                .Where(pNodeOp=>pNodeOp.Optimizable(pNode.Type))
                .Any(pNodeOp=>pNodeOp.OptimizeNode(pNode)))
            {
                return true;
            }

            for (int i = 0, c = pNode.Children.Count; i < c; i++)
            {
                Node child = pNode.Children[i];
                foreach (iOptimizer nodeOp in _optimizers)
                {
                    if (nodeOp.Optimizable(pNode.Type)
                        && nodeOp.OptimizeParent(pNode, child))
                    {
                        return true;
                    }
                    if (nodeOp.Optimizable(child.Type)
                        && nodeOp.OptimizeChild(pNode, child))
                    {
                        return true;
                    }
                }

                if (OptimizeNode(child))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Performs optimization of a node tree.
        /// </summary>
        /// <param name="pRoot">The root node</param>
        /// <returns>A node to used as the new root node.</returns>
        public Node Optimize(Node pRoot)
        {
            _cursor = new Cursor();
            using (_executor = new Executor(_cursor))
            {
                _optimizers = ObjectFactory.CreateNodeOptimizers(_executor);

                try
                {
                    while (OptimizeNode(pRoot))
                    {
                    }

                    PostOptimize(pRoot);
                }
                catch (PrometheusException e)
                {
                    if (_cursor.Node != null && e.Where == null)
                    {
                        e.Where = _cursor.Node.Location;
                    }
                    throw;
                }

                return pRoot;
            }
        }

        /// <summary>
        /// Walks the entire tree calling PostOptimize
        /// </summary>
        private void PostOptimize(Node pNode)
        {
            _optimizers
                .Where(pNodeOp=>pNodeOp.Optimizable(pNode.Type))
                .ToList()
                .ForEach(pNodeOp=>pNodeOp.OptimizePost(pNode));

            pNode.Children.ForEach(PostOptimize);
        }
    }
}