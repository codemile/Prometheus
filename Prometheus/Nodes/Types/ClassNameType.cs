using System;
using System.Diagnostics;
using System.Linq;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Points to a class declaration in a namespace
    /// </summary>
    [DebuggerDisplay("{NameSpace}:{Identifier}")]
    public class ClassNameType : DataType
    {
        /// <summary>
        /// The name of the object.
        /// </summary>
        public readonly IdentifierType Identifier;

        /// <summary>
        /// The namespace this declaration is in.
        /// </summary>
        public readonly QualifiedType NameSpace;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pNameSpace">The namespace</param>
        /// <param name="pName">The class name</param>
        public ClassNameType(QualifiedType pNameSpace, IdentifierType pName)
        {
            NameSpace = pNameSpace;
            Identifier = pName;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ClassNameType(string pClassName)
        {
            string[] parts = pClassName.Split(new[] { '.' });
            NameSpace = new QualifiedType(parts.Take(parts.Length-1).ToArray());
            Identifier = new IdentifierType(parts[parts.Length-1]);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ClassNameType(Type pType)
            : this(pType.FullName)
        {
            
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            //return string.Format("@{0}:{1}", NameSpace, Identifier);
            return string.Format("{0}.{1}", NameSpace, Identifier);
        }
    }
}