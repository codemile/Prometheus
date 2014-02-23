using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Represents a plural variable associated with a singular name.
    /// </summary>
    public class PluralType : DataType
    {
        /// <summary>
        /// The contents of the plural identifier.
        /// </summary>
        public readonly ArrayType Array;

        /// <summary>
        /// The name of the singular identifier.
        /// </summary>
        public readonly IdentifierType Singular;

        /// <summary>
        /// Constructor
        /// </summary>
        public PluralType(ArrayType pArray, IdentifierType pSingular)
        {
            Array = pArray;
            Singular = pSingular;
        }
    }
}