using System.Collections.Generic;
using System.Linq;
using Prometheus.Grammar;
using Prometheus.Nodes;

namespace Prometheus.Compile.Packaging
{
    /// <summary>
    /// Represents all the compiled code.
    /// </summary>
    public class Compiled
    {
        /// <summary>
        /// Symbols of code to go to the footer.
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _footerTypes = new HashSet<GrammarSymbol>();

        /// <summary>
        /// Symbols of code to go to the header.
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _headerTypes = new HashSet<GrammarSymbol>
                                                                      {
                                                                          GrammarSymbol.ObjectDecl
                                                                      };

        /// <summary>
        /// The root node
        /// </summary>
        public readonly Node Root;

        /// <summary>
        /// The code in the middle.
        /// </summary>
        private readonly Node _body;

        /// <summary>
        /// The code at the bottom.
        /// </summary>
        private readonly Node _footer;

        /// <summary>
        /// The code at the top.
        /// </summary>
        private readonly Node _header;

        private static Node CreateNameSpace(ClassNameType pClassName, IEnumerable<Node> pNodes)
        {
            Node ns = new Node(GrammarSymbol.NameSpace, Location.None);
            ns.Data.Add(pClassName);
            ns.Children.AddRange(pNodes);
            return ns;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Compiled()
        {
            Root = new Node(GrammarSymbol.Program, Location.None);

            _header = new Node(GrammarSymbol.Statements, Location.None);
            _body = new Node(GrammarSymbol.Statements, Location.None);
            _footer = new Node(GrammarSymbol.Statements, Location.None);

            Root.Children.Add(_header);
            Root.Children.Add(_body);
            Root.Children.Add(_footer);
        }

        /// <summary>
        /// Adds a compiled node tree to the package.
        /// </summary>
        public void Add(ClassNameType pPackage, Node pRoot)
        {
            _header.Children.Add(CreateNameSpace(pPackage, from node in pRoot.Children
                                                           where _headerTypes.Contains(node.Type)
                                                           select node));

            _body.Children.Add(CreateNameSpace(pPackage, from node in pRoot.Children
                                                         where !_headerTypes.Contains(node.Type)
                                                               && !_footerTypes.Contains(node.Type)
                                                         select node));

            _footer.Children.Add(CreateNameSpace(pPackage, from node in pRoot.Children
                                                           where _footerTypes.Contains(node.Type)
                                                           select node));
        }
    }
}