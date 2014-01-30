using Prometheus.Compile;

namespace Prometheus.Tokens.Expressions
{
    /// <summary>
    /// A base implement for math expressions that are performed with
    /// a left and right side values.
    /// </summary>
    public abstract class OperatorExpression : BaseExpression
    {
        /// <summary>
        /// Left side of the operation
        /// </summary>
        protected BaseExpression Left { get; private set; }

        /// <summary>
        /// Right side of the operation
        /// </summary>
        protected BaseExpression Right { get; private set; }

        /// <summary>
        /// Returns the child expression when chaining.
        /// </summary>
        private BaseExpression _child
        {
            get { return Left; }
            set { Left = value; }
        }

        /// <summary>
        /// True if this expression is chaining.
        /// </summary>
        private bool _isPassThru
        {
            get { return Left != null && Right == null; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        protected OperatorExpression(Context pContext, Cursor pCursor, BaseExpression pChild)
            : base(pContext, pCursor)
        {
            _child = pChild;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        protected OperatorExpression(Context pContext, Cursor pCursor, BaseExpression pLeft,
                                     BaseExpression pRight)
            : base(pContext, pCursor)
        {
            Left = pLeft;
            Right = pRight;
        }

        /// <summary>
        /// Derived classes should implement this to perform the operation.
        /// </summary>
        protected abstract bool OperationBool(BaseExpression pLeft, BaseExpression pRight);

        /// <summary>
        /// Derived classes should implement this to perform the operation.
        /// </summary>
        protected abstract int OperationInt(BaseExpression pLeft, BaseExpression pRight);

        /// <summary>
        /// Derived classes should implement this to perform the operation.
        /// </summary>
        protected abstract float OperationPrecise(BaseExpression pLeft, BaseExpression pRight);

        /// <summary>
        /// Derived classes should implement this to perform the operation.
        /// </summary>
        protected abstract string OperationString(BaseExpression pLeft, BaseExpression pRight);

        /// <summary>
        /// Evaluates the expression depending upon how many arguments
        /// were provided.
        /// </summary>
        public override bool getBool()
        {
            return _isPassThru ? _child.getBool() : OperationBool(Left, Right);
        }

        /// <summary>
        /// Evaluates the expression depending upon how many arguments
        /// were provided.
        /// </summary>
        public override int getInt()
        {
            return _isPassThru ? _child.getInt() : OperationInt(Left, Right);
        }

        /// <summary>
        /// Evaluates the expression depending upon how many arguments
        /// were provided.
        /// </summary>
        public override float getPrecise()
        {
            return _isPassThru ? _child.getPrecise() : OperationPrecise(Left, Right);
        }

        /// <summary>
        /// Evaluates the expression depending upon how many arguments
        /// were provided.
        /// </summary>
        public override string getString()
        {
            return _isPassThru ? _child.getString() : OperationString(Left, Right);
        }
    }
}