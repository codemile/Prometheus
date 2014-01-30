using Prometheus.Compile;
using Prometheus.Exceptions.Compiler;

namespace Prometheus.Tokens.Expressions
{
    /// <summary>
    /// Performs division
    /// </summary>
    public class DivideExpression : OperatorExpression
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DivideExpression(Context pContext, Cursor pCursor, BaseExpression pChild)
            : base(pContext, pCursor, pChild)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public DivideExpression(Context pContext, Cursor pCursor, BaseExpression pLeft, BaseExpression pRight)
            : base(pContext, pCursor, pLeft, pRight)
        {
        }

        /// <summary>
        /// Invalid operation.
        /// </summary>
        protected override bool OperationBool(BaseExpression pLeft, BaseExpression pRight)
        {
            throw new OperatorException("Operator '/' cannot be applied to operands of type 'bool' and 'bool'", Cursor);
        }

        /// <summary>
        /// Perform the division
        /// </summary>
        protected override int OperationInt(BaseExpression pLeft, BaseExpression pRight)
        {
            return pLeft.getInt() / pRight.getInt();
        }

        /// <summary>
        /// Perform the division
        /// </summary>
        protected override float OperationPrecise(BaseExpression pLeft, BaseExpression pRight)
        {
            // Allow C# to throw a divide by zero exception.
            return pLeft.getPrecise() / pRight.getPrecise();
        }

        /// <summary>
        /// Invalid operation.
        /// </summary>
        protected override string OperationString(BaseExpression pLeft, BaseExpression pRight)
        {
            // TODO: Would be nice to use the divide operator as a short hand way to split a string, but at this
            //       stage I don't support arrays.
            throw new OperatorException("Operator '/' cannot be applied to operands of type 'string' and 'string'",
                Cursor);
        }
    }
}