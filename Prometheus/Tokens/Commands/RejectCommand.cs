using Prometheus.Documents;
using Prometheus.Tokens.Expressions;

namespace Prometheus.Tokens.Commands
{
    /// <summary>
    /// Sets the current state to rejected if the expression is true, and
    /// does nothing if it is false.
    /// </summary>
    public class RejectCommand : Command
    {
        /// <summary>
        /// The expression
        /// </summary>
        private BaseExpression _expression { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public RejectCommand(Context pContext, Cursor pCursor, BaseExpression pExpression)
            : base(pContext, pCursor)
        {
            _expression = pExpression;
        }

        /// <summary>
        /// Handles rejecting a document.
        /// </summary>
        protected override bool Executing()
        {
            if (_expression.getBool())
            {
                Context.Status = Context.StatusType.REJECTED;
            }
            return true;
        }
    }
}