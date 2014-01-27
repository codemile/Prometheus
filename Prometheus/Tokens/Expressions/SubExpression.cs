using Prometheus.Documents;
using Prometheus.Exceptions;

namespace Prometheus.Tokens.Expressions
{
    /// <summary>
    /// Performs subtraction
    /// </summary>
    public class SubExpression : OperatorExpression
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SubExpression(Context pContext, DocumentCursor pCursor, BaseExpression pChild)
            : base(pContext, pCursor, pChild)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public SubExpression(Context pContext, DocumentCursor pCursor, BaseExpression pLeft, BaseExpression pRight)
            : base(pContext, pCursor, pLeft, pRight)
        {
        }

        /// <summary>
        /// Invalid operation.
        /// </summary>
        protected override bool OperationBool(BaseExpression pLeft, BaseExpression pRight)
        {
            throw new OperatorException("Operator '-' cannot be applied to operands of type 'bool' and 'bool'", Cursor);
        }

        /// <summary>
        /// Performs the subtraction.
        /// </summary>
        protected override int OperationInt(BaseExpression pLeft, BaseExpression pRight)
        {
            return pLeft.getInt() - pRight.getInt();
        }

        /// <summary>
        /// Performs the subtraction.
        /// </summary>
        protected override float OperationPrecise(BaseExpression pLeft, BaseExpression pRight)
        {
            return pLeft.getPrecise() - pRight.getPrecise();
        }

        /// <summary>
        /// Invalid operation.
        /// </summary>
        protected override string OperationString(BaseExpression pLeft, BaseExpression pRight)
        {
            throw new OperatorException("Operator '-' cannot be applied to operands of type 'string' and 'string'",
                Cursor);
        }
    }
}