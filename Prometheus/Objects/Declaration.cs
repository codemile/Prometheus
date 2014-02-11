using System.Diagnostics;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;

namespace Prometheus.Objects
{
    /// <summary>
    /// Holds the definition of an object.
    /// </summary>
    [DebuggerDisplay("{ClassName}")]
    public class Declaration
    {
        /// <summary>
        /// The base class of the object.
        /// </summary>
        public readonly Declaration Base;

        /// <summary>
        /// The constructor function.
        /// </summary>
        public readonly Node Constructor;

        /// <summary>
        /// The name of the class this declaration creates.
        /// </summary>
        public readonly ClassNameType ClassName;

        /// <summary>
        /// Constructor
        /// </summary>
        public Declaration(ClassNameType pClassName, Declaration pBase, Node pObjDecl)
        {
            ClassName = pClassName;
            Base = pBase;

            Constructor = new Node(GrammarSymbol.Statements, pObjDecl.Location);
            Constructor.Children.AddRange(pObjDecl.Children);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return ClassName.ToString();
        }
    }
}