using System.Diagnostics;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Holds the definition of an object.
    /// </summary>
    [DebuggerDisplay("{{ClassName}}")]
    public class DeclarationType : DataType
    {
        /// <summary>
        /// The name of the object
        /// </summary>
        public readonly QualifiedType ClassName;

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
        public DeclarationType(QualifiedType pBase, QualifiedType pClassName, ClosureType pConstructor)
            : this(pClassName, pConstructor)
        {
            ClassName = pClassName;
            Base = pBase;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public DeclarationType(QualifiedType pClassName, ClosureType pConstructor)
        {
            ClassName = pClassName;
            Constructor = pConstructor;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            if (Base == null)
            {
                return "object::" + ClassName;
            }
            return Base+"::"+ClassName;
        }
    }
}