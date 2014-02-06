using System.Diagnostics;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Holds the multi-part names that reference a variable in memory.
    /// </summary>
    [DebuggerDisplay("{_fullName}")]
    public class Qualified
    {
        /// <summary>
        /// The original name
        /// </summary>
        private readonly string _fullName;

        /// <summary>
        /// The parts of the name
        /// </summary>
        public readonly string[] Parts;

        /// <summary>
        /// Constructor
        /// </summary>
        public Qualified(string[] pParts)
        {
            _fullName = string.Join(".", pParts);
            Parts = pParts;
        }

        /// <summary>
        /// The identifier name
        /// </summary>
        public override string ToString()
        {
            return _fullName;
        }
    }
}