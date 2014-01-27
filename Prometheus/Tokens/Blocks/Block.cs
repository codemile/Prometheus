using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Prometheus.Documents;
using Prometheus.Tokens.Statements;

namespace Prometheus.Tokens.Blocks
{
    /// <summary>
    /// A base class for defining a block of statements.
    /// </summary>
    public class Block : Statement, IEnumerable<Statement>
    {
        /// <summary>
        /// The number of statements in the block.
        /// </summary>
        public int Count
        {
            get { return _statements.Count; }
        }

        /// <summary>
        /// Index access to statements.
        /// </summary>
        public Statement this[int i]
        {
            get { return _statements[i]; }
        }

        /// <summary>
        /// Statements are executed in the order found in the list.
        /// </summary>
        private List<Statement> _statements { get; set; }

        /// <summary>
        /// The statements in a block can be iterated.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _statements.GetEnumerator();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Block(Context pContext, Cursor pCursor, IEnumerable<Statement> pStatements)
            : base(pContext, pCursor)
        {
            _statements = new List<Statement>(pStatements);
        }

        /// <summary>
        /// Executes all the statements of the block.
        /// </summary>
        protected override bool Executing()
        {
            return this.All(pStatement=>pStatement.Execute());
        }

        /// <summary>
        /// The statements in a block can be iterated.
        /// </summary>
        public IEnumerator<Statement> GetEnumerator()
        {
            return _statements.GetEnumerator();
        }
    }
}