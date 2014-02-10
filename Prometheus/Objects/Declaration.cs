using System.Diagnostics;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;

namespace Prometheus.Objects
{
    /// <summary>
    /// Holds the definition of an object.
    /// </summary>
    [DebuggerDisplay("{Name}")]
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
        /// The name of the object.
        /// </summary>
        public readonly IdentifierType Name;

        /// <summary>
        /// Constructor
        /// </summary>
        public Declaration(Declaration pBase, IdentifierType pName, Node pObjDecl)
        {
            Base = pBase;
            Name = pName;

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
            return string.Format("{0}:{1}", Base ?? (object)"", Name);
        }
    }
}