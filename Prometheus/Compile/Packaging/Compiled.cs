using System.Collections.Generic;
using Prometheus.Nodes;

namespace Prometheus.Compile.Packaging
{
    /// <summary>
    /// Represents all the compiled code.
    /// </summary>
    public class Compiled
    {
        /// <summary>
        /// The files that have been compiled.
        /// </summary>
        public readonly HashSet<string> Files; 

        /// <summary>
        /// The compiled files in order of importing.
        /// </summary>
        public readonly List<Node> Imported;

        /// <summary>
        /// The original file that was compiled.
        /// </summary>
        public Node Root { get { return Imported[Imported.Count - 1]; }}

        /// <summary>
        /// Constructor
        /// </summary>
        public Compiled()
        {
            Imported = new List<Node>();
            Files = new HashSet<string>();
        }
    }
}