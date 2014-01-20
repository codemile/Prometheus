using Markdown.Documents;

namespace Prometheus.Tokens
{
    /// <summary>
    /// The base class for all objects created by the parser.
    /// </summary>
    public abstract class Token
    {
        /// <summary>
        /// The program context (all tokens share the same reference).
        /// </summary>
        protected Context Context { get; private set; }

        /// <summary>
        /// The location in the source code.
        /// </summary>
        protected DocumentCursor Cursor { get; private set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        protected Token(Context pContext)
        {
            Cursor = DocumentCursor.None;
            Context = pContext;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        protected Token(Context pContext, DocumentCursor pCursor)
        {
            Cursor = pCursor;
            Context = pContext;
        }

        /// <summary>
        /// Show the name in debugger.
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0} {1}", GetType().Name, Cursor);
        }
    }
}