using System;
using Prometheus.Documents;
using Prometheus.Exceptions;

namespace Prometheus.Tokens.Expressions
{
    /// <summary>
    /// Used to chain expressions together.
    /// </summary>
    public class Expression : OperatorExpression
    {
        /// <summary>
        /// A logical operator that joins two terms.
        /// </summary>
        public string Operator { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Expression(Context pContext, Cursor pCursor, BaseExpression pLeft, string pOperator,
                          BaseExpression pRight)
            : base(pContext, pCursor, pLeft, pRight)
        {
            Operator = pOperator;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Expression(Context pContext, Cursor pCursor, BaseExpression pChild)
            : base(pContext, pCursor, pChild)
        {
        }

        protected override bool OperationBool(BaseExpression pLeft, BaseExpression pRight)
        {
            switch (Operator)
            {
                case ">":
                    return Left.getPrecise() > Right.getPrecise();
                case "<":
                    return Left.getPrecise() < Right.getPrecise();
                case ">=":
                    return Left.getPrecise() >= Right.getPrecise();
                case "<=":
                    return Left.getPrecise() <= Right.getPrecise();
                case "==":
                    return Math.Abs(Left.getPrecise() - Right.getPrecise()) < Single.Epsilon;
                case "<>":
                case "!=":
                    return Math.Abs(Left.getPrecise() - Right.getPrecise()) > Single.Epsilon;

                case "&&":
                case "and":
                    return Left.getBool() && Right.getBool();
                case "||":
                case "or":
                    return Left.getBool() || Right.getBool();
            }
            throw new OperatorException(
                string.Format("Operator '{0}' cannot be applied operands of type 'bool' and 'bool'", Operator), Cursor);
        }

        protected override int OperationInt(BaseExpression pLeft, BaseExpression pRight)
        {
            throw new OperatorException(
                string.Format("Operator '{0}' cannot be applied operands of type 'int' and 'int'", Operator), Cursor);
        }

        protected override float OperationPrecise(BaseExpression pLeft, BaseExpression pRight)
        {
            throw new OperatorException(
                string.Format("Operator '{0}' cannot be applied operands of type 'float' and 'float'", Operator), Cursor);
        }

        protected override string OperationString(BaseExpression pLeft, BaseExpression pRight)
        {
            throw new OperatorException(
                string.Format("Operator '{0}' cannot be applied operands of type 'string' and 'string'", Operator),
                Cursor);
        }
    }
}