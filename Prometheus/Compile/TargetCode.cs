using System.Collections.Generic;
using Prometheus.Nodes;

namespace Prometheus.Compile
{
    /// <summary>
    /// The output produced by the compiler.
    /// </summary>
    public class TargetCode
    {
        /// <summary>
        /// The root node of the compiled tree.
        /// </summary>
        public readonly Node Root;

        /// <summary>
        /// A list of source codes used to produce the target.
        /// </summary>
        public readonly List<TargetSource> Sources;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pRoot">Root node</param>
        public TargetCode(Node pRoot)
        {
            Root = pRoot;

            Sources = new List<TargetSource>();
        }
    }
}