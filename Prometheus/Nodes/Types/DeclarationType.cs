using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Holds the definition of an object.
    /// </summary>
    public class DeclarationType : DataType
    {
        /// <summary>
        /// The base class of the object.
        /// </summary>
        public readonly QualifiedType Base;

        /// <summary>
        /// The constructor function.
        /// </summary>
        public readonly ClosureType Constructor;

        /// <summary>
        /// Constructor
        /// </summary>
        public DeclarationType(QualifiedType pBase, ClosureType pConstructor)
            : this(pConstructor)
        {
            Base = pBase;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public DeclarationType(ClosureType pConstructor)
        {
            Constructor = pConstructor;
        }
    }
}