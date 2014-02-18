using System.Collections.Generic;
using System.Linq;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;

namespace Prometheus.Compile.Packaging
{
    /// <summary>
    /// The output produced by the compiler.
    /// </summary>
    public class Compiled
    {
        /// <summary>
        /// The name of the package this code belongs to.
        /// </summary>
        public readonly ClassNameType Package;

        /// <summary>
        /// A list of packages this target depends on.
        /// </summary>
        public readonly List<ClassNameType> Uses;

        /// <summary>
        /// The root node of the compiled tree.
        /// </summary>
        public readonly Node Root;

        /// <summary>
        /// A list of object declarations
        /// </summary>
        public readonly List<Node> Declarations;

        /// <summary>
        /// The root node for the source code in the file (after the declarations).
        /// </summary>
        public readonly Node Code;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pPackage">The package this code belongs to</param>
        /// <param name="pRoot">Root node</param>
        public Compiled(ClassNameType pPackage, Node pRoot)
        {
            Package = pPackage;
            Root = pRoot;

            // read the imports
            Uses = (from node in Root.Children
                    where node.Type == GrammarSymbol.ImportDecl
                    select node.FirstChild().FirstData().Cast<ClassNameType>()).ToList();

            // read the object declarations
            Declarations = (from node in Root.Children
                            where node.Type == GrammarSymbol.ObjectDecl
                            select node).ToList();

            // the executable for the file.
            Code = Root.Children.FirstOrDefault(pNode=>pNode.Type == GrammarSymbol.ProgramCode);
        }
    }
}