using System.Diagnostics;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Holds the multi-part names that reference a variable in memory.
    /// </summary>
    [DebuggerDisplay("{_fullName}")]
    public class QualifiedType
    {
        /// <summary>
        /// The parts of the name
        /// </summary>
        public readonly string[] Parts;

        /// <summary>
        /// The original name
        /// </summary>
        private readonly string _fullName;

        /// <summary>
        /// Constructor
        /// </summary>
        public QualifiedType(string[] pParts)
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