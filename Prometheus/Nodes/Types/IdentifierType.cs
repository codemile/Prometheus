using System.Diagnostics;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Holds the name of a reference, such as a variable name.
    /// </summary>
    [DebuggerDisplay("{Name}")]
    public class IdentifierType : DataType
    {
        /// <summary>
        /// the display name
        /// </summary>
        public readonly string FullName;

        /// <summary>
        /// A cache of the name parts.
        /// </summary>
        private string[] _parts;

        /// <summary>
        /// The member name only
        /// </summary>
        public string Name
        {
            get { return FullName == "" ? "" : _parts[_parts.Length - 1]; }
        }

        /// <summary>
        /// The name broken into namespaces and member
        /// </summary>
        public string[] Parts
        {
            get { return _parts ?? (_parts = FullName.Split(new[] {'.'})); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public IdentifierType(string pFullName)
        {
            FullName = pFullName.ToLower();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public IdentifierType(string[] pParts)
        {
            FullName = string.Join(".", pParts);
            _parts = pParts;
        }

        /// <summary>
        /// The identifier name
        /// </summary>
        public override string ToString()
        {
            return FullName;
        }
    }
}