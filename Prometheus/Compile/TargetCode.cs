using System.Collections.Generic;
using Prometheus.Nodes;

namespace Prometheus.Compile
{
    /// <summary>
    /// The output produced by the compiler.
    /// </summary>
    public class TargetCode : iSourceRef
    {
        /// <summary>
        /// The root node of the compiled tree.
        /// </summary>
        public readonly Node Root;

        /// <summary>
        /// A list of source codes used to produce the target.
        /// </summary>
        private readonly List<TargetSource> _sources;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pRoot">Root node</param>
        public TargetCode(Node pRoot)
        {
            Root = pRoot;

            _sources = new List<TargetSource>();
        }

        /// <summary>
        /// The file name for the source code.
        /// </summary>
        /// <param name="pSource">The source ref number.</param>
        /// <returns>The file name</returns>
        public string getFileName(int pSource)
        {
            return _sources[pSource].FileName;
        }
    }
}