using Prometheus.Documents;
using Prometheus.Tokens.Expressions;

namespace Prometheus.Tokens.Commands
{
    /// <summary>
    /// Sets the current state to accepted if the expression is true, and
    /// does nothing if it is false.
    /// </summary>
    public class AcceptCommand : Command
    {
        /// <summary>
        /// The expression
        /// </summary>
        private BaseExpression _expression { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public AcceptCommand(Context pContext, Cursor pCursor, BaseExpression pExpression)
            : base(pContext, pCursor)
        {
            _expression = pExpression;
        }

        /// <summary>
        /// Handles accepting a document.
        /// </summary>
        protected override bool Executing()
        {
            if (_expression.getBool())
            {
                Context.Status = Context.StatusType.ACCEPTED;
            }
            return true;
        }
    }
}