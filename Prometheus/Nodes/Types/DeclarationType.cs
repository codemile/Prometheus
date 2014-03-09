using System.Diagnostics;
using Prometheus.Nodes.Types.Attributes;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Holds the definition of an object.
    /// </summary>
    [DebuggerDisplay("{{ClassName}}")]
    [DataTypeInfo("Class")]
    public class DeclarationType : DataType
    {
        /// <summary>
        /// The base class of the object.
        /// </summary>
        public readonly QualifiedType Base;

        /// <summary>
        /// The name of the object
        /// </summary>
        public readonly QualifiedType ClassName;

        /// <summary>
        /// The constructor function.
        /// </summary>
        public readonly FunctionType Constructor;

        /// <summary>
        /// Constructor
        /// </summary>
        public DeclarationType(QualifiedType pBase, QualifiedType pClassName, FunctionType pConstructor)
            : this(pClassName, pConstructor)
        {
            ClassName = pClassName;
            Base = pBase;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public DeclarationType(QualifiedType pClassName, FunctionType pConstructor)
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
            return Base + "::" + ClassName;
        }
    }
}