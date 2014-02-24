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
        /// Constant this
        /// </summary>
        public static readonly QualifiedType This = new QualifiedType(THIS);

        /// <summary>
        /// Reference to "base"
        /// </summary>
        public const string BASE = "base";

        /// <summary>
        /// Reference to "this"
        /// </summary>
        public const string THIS = "this";

        /// <summary>
        /// Reference to closure function scope.
        /// </summary>
        public const string FUNC = "func";

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
                //throw new InternalErrorException(string.Format("Qualifier used as identifier <{0}>", pName));
            }
#endif
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