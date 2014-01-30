using System.Linq;
using Prometheus.Compile;
using Prometheus.Exceptions.Compiler;

namespace Prometheus.Tokens.Expressions
{
    /// <summary>
    /// Performs multiplication
    /// </summary>
    public class MultiplyExpression : OperatorExpression
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MultiplyExpression(Context pContext, Cursor pCursor, BaseExpression pChild)
            : base(pContext, pCursor, pChild)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public MultiplyExpression(Context pContext, Cursor pCursor, BaseExpression pLeft, BaseExpression pRight)
            : base(pContext, pCursor, pLeft, pRight)
        {
        }

        /// <summary>
        /// Invalid operation.
        /// </summary>
        protected override bool OperationBool(BaseExpression pLeft, BaseExpression pRight)
        {
            throw new OperatorException("Operator '*' cannot be applied to operands of type 'bool' and 'bool'", Cursor);
        }

        /// <summary>
        /// Perform the multiplication
        /// </summary>
        protected override int OperationInt(BaseExpression pLeft, BaseExpression pRight)
        {
            return pLeft.getInt() * pRight.getInt();
        }

        /// <summary>
        /// Perform the multiplication
        /// </summary>
        protected override float OperationPrecise(BaseExpression pLeft, BaseExpression pRight)
        {
            return pLeft.getPrecise() * pRight.getPrecise();
        }

        /// <summary>
        /// Use the multiplication operator to repeat strings.
        /// </summary>
        protected override string OperationString(BaseExpression pLeft, BaseExpression pRight)
        {
            return string.Concat(Enumerable.Repeat(pLeft.getString(), pRight.getInt()));
        }
    }
}