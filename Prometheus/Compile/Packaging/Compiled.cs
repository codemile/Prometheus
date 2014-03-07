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
        /// The files that have been compiled.
        /// </summary>
        public readonly HashSet<string> Files;

        /// <summary>
        /// The compiled files in order of importing.
        /// </summary>
        public readonly List<Node> Imported;

        /// <summary>
        /// The original file that was compiled.
        /// </summary>
        public Node Root
        {
            get { return Imported[Imported.Count - 1]; }
        }

        private static bool IsTestSuite(Node pNode)
        {
            return pNode.HasChild(GrammarSymbol.TestSuiteDecl);
        }

        /// <summary>
        /// True if compiled program is a test suite.
        /// </summary>
        public bool TestSuite
        {
            get { return IsTestSuite(Root); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Compiled()
        {
            Imported = new List<Node>();
            Files = new HashSet<string>();
        }

        /// <summary>
        /// All the compiled nodes that are test suites.
        /// </summary>
        public IEnumerable<Node> getTestNodes()
        {
            return from node in Imported where IsTestSuite(node) select node;
        }

        /// <summary>
        /// All the compiled nodes that are executable code.
        /// </summary>
        public IEnumerable<Node> getNodes()
        {
            return from node in Imported where !IsTestSuite(node) select node;
        }
    }
}