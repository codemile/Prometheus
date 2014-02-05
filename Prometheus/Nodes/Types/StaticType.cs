using System.Diagnostics;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Refers to a string that defines a static type (int, object, class, etc..)
    /// </summary>
    [DebuggerDisplay("{Name}")]
    public class StaticType
    {
        /// <summary>
        /// the display name
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Constructor
        /// </summary>
        public StaticType(string pName)
        {
            Name = pName.ToLower();
        }

        /// <summary>
        /// The identifier name
        /// </summary>
        public override string ToString()
        {
            return Name;
        }
    }
}