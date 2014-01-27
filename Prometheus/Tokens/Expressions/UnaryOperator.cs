using Prometheus.Documents;
using Prometheus.Exceptions;
using Prometheus.Tokens.Arguments;

namespace Prometheus.Tokens.Expressions
{
    /// <summary>
    /// Holds a single value that is fed into an expression chain.
    /// </summary>
    public class UnaryOperator : BaseExpression
    {
        /// <summary>
        /// What type of unary operation.
        /// </summary>
        private string _operator { get; set; }

        /// <summary>
        /// The value
        /// </summary>
        private Ref _value { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public UnaryOperator(Context pContext, Cursor pCursor, Ref pValue)
            : base(pContext, pCursor)
        {
            _value = pValue;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public UnaryOperator(Context pContext, Cursor pCursor, string pOperator, Ref pValue)
            : base(pContext, pCursor)
        {
            _operator = pOperator;
            _value = pValue;
        }

        /// <summary>
        /// Return the value as a boolean.
        /// </summary>
        public override bool getBool()
        {
            switch (_operator)
            {
                case "+":
                case "-":
                case "~":
                    throw new OperatorException(
                        string.Format("Unary operator '{0}' cannot be applied to type 'boolean'", _operator), Cursor);
                case "!":
                case "not":
                    return !_value.getBool();
            }
            return _value.getBool();
        }

        /// <summary>
        /// Return the value as a int.
        /// </summary>
        public override int getInt()
        {
            switch (_operator)
            {
                case "-":
                    return -_value.getInt();
                case "+":
                    return +_value.getInt();
                case "!":
                case "not":
                    throw new OperatorException(
                        string.Format("Unary operator '{0}' cannot be applied to type 'integer'", _operator), Cursor);
                case "~":
                    return ~_value.getInt();
            }
            return _value.getInt();
        }

        /// <summary>
        /// Return the value as a float.
        /// </summary>
        public override float getPrecise()
        {
            switch (_operator)
            {
                case "-":
                    return -_value.getPrecise();
                case "+":
                    return +_value.getPrecise();
                case "!":
                case "not":
                case "~":
                    throw new OperatorException(
                        string.Format("Unary operator '{0}' cannot be applied to type 'float'", _operator), Cursor);
            }
            return _value.getPrecise();
        }

        /// <summary>
        /// Return the value as a string.
        /// </summary>
        public override string getString()
        {
            if (_operator == null)
            {
                return _value.getString();
            }
            throw new OperatorException(
                string.Format("Unary operator '{0}' cannot be applied to type 'string'", _operator), Cursor);
        }
    }
}