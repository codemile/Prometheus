using Markdown.Documents;

namespace Prometheus.Tokens.Statements
{
    public class Statements : Statement
    {
        /// <summary>
        /// THe first statement.
        /// </summary>
        public Statement Left { get; private set; }

        /// <summary>
        /// The second statement.
        /// </summary>
        public Statement Right { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Statements(Context pContext, DocumentCursor pCursor, Statement pLeft, Statement pRight)
            : base(pContext, pCursor)
        {
            Left = pLeft;
            Right = pRight;
        }

        /// <summary>
        /// Executes the inner statements.
        /// </summary>
        protected override bool Executing()
        {
            return Left.Execute() && Right.Execute();
        }
    }
}