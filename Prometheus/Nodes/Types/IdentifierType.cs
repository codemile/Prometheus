using System.Diagnostics;
using Prometheus.Exceptions.Compiler;
using Prometheus.Exceptions.Executor;
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
        /// Reference to "this"
        /// </summary>
        public static readonly IdentifierType This = new IdentifierType("this");

        /// <summary>
        /// Reference to "base"
        /// </summary>
        public static readonly IdentifierType Base = new IdentifierType("base");

        /// <summary>
        /// the display name
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Constructor
        /// </summary>
        public IdentifierType(string pName)
        {
            Name = pName.ToLower();
#if DEBUG
            if (Name.Contains("."))
            {
                throw new InternalErrorException(string.Format("Qualifier used as identifier <{0}>", pName));
            }
#endif
        }

        /// <summary>
        /// The identifier name
        /// </summary>
        public override string ToString()
        {
            return "#"+Name;
        }
    }
}