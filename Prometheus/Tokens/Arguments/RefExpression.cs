using Prometheus.Documents;
using Prometheus.Tokens.Expressions;

namespace Prometheus.Tokens.Arguments
{
    /// <summary>
    /// Holds a reference to an expression.
    /// </summary>
    public class RefExpression : Ref
    {
        /// <summary>
        /// The expression.
        /// </summary>
        private BaseExpression _expression { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public RefExpression(Context pContext, DocumentCursor pCursor, BaseExpression pExpression)
            : base(pContext, pCursor)
        {
            _expression = pExpression;
        }

        /// <summary>
        /// Returns the result of the expression as a boolean.
        /// </summary>
        public override bool getBool()
        {
            return _expression.getBool();
        }

        /// <summary>
        /// Returns the result of the expression as a int.
        /// </summary>
        public override int getInt()
        {
            return _expression.getInt();
        }

        /// <summary>
        /// Returns the result of the expression as a float.
        /// </summary>
        public override float getPrecise()
        {
            return _expression.getPrecise();
        }

        /// <summary>
        /// Returns the result of the expression as a string.
        /// </summary>
        public override string getString()
        {
            return _expression.getString();
        }
    }
}