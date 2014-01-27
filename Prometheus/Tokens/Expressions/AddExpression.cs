using Prometheus.Documents;
using Prometheus.Exceptions;

namespace Prometheus.Tokens.Expressions
{
    /// <summary>
    /// Performs addition
    /// </summary>
    public class AddExpression : OperatorExpression
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AddExpression(Context pContext, Cursor pCursor, BaseExpression pChild)
            : base(pContext, pCursor, pChild)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public AddExpression(Context pContext, Cursor pCursor, BaseExpression pLeft, BaseExpression pRight)
            : base(pContext, pCursor, pLeft, pRight)
        {
        }

        /// <summary>
        /// Invalid operation.
        /// </summary>
        protected override bool OperationBool(BaseExpression pLeft, BaseExpression pRight)
        {
            throw new OperatorException("Operator '+' cannot be applied to operands of type 'bool' and 'bool'", Cursor);
        }

        /// <summary>
        /// Performs the addition.
        /// </summary>
        protected override int OperationInt(BaseExpression pLeft, BaseExpression pRight)
        {
            return pLeft.getInt() + pRight.getInt();
        }

        /// <summary>
        /// Performs the addition.
        /// </summary>
        protected override float OperationPrecise(BaseExpression pLeft, BaseExpression pRight)
        {
            return pLeft.getPrecise() + pRight.getPrecise();
        }

        /// <summary>
        /// Performs the addition.
        /// </summary>
        protected override string OperationString(BaseExpression pLeft, BaseExpression pRight)
        {
            return pLeft.getString() + pRight.getString();
        }
    }
}