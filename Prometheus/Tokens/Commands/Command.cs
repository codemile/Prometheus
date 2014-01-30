using Prometheus.Compile;
using Prometheus.Tokens.Statements;

namespace Prometheus.Tokens.Commands
{
    /// <summary>
    /// Base implementation for commands
    /// </summary>
    public abstract class Command : Statement
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected Command(Context pContext, Cursor pCursor)
            : base(pContext, pCursor)
        {
        }
    }
}