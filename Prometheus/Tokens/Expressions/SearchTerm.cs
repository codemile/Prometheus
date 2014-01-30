using System.Linq;
using Prometheus.Compile;
using Prometheus.Exceptions;

namespace Prometheus.Tokens.Expressions
{
    /// <summary>
    /// Performs division
    /// </summary>
    public class SearchTerm : BaseExpression
    {
        /// <summary>
        /// The needle value to look for.
        /// </summary>
        private BaseExpression _expression { get; set; }

        /// <summary>
        /// The type of search to perform.
        /// </summary>
        private string _statement { get; set; }

        /// <summary>
        /// Perform the "has" operation.
        /// </summary>
        private bool Has(string pTerm)
        {
            return Context.getFragments(Cursor).Any(pFrag=>pFrag.Text.Contains(pTerm));
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public SearchTerm(Context pContext, Cursor pCursor, BaseExpression pExpression)
            : base(pContext, pCursor)
        {
            _expression = pExpression;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public SearchTerm(Context pContext, Cursor pCursor, string pStatement, BaseExpression pExpression)
            : base(pContext, pCursor)
        {
            _statement = pStatement;
            _expression = pExpression;
        }

        /// <summary>
        /// Attempts to convert the string value to a boolean.
        /// </summary>
        public override bool getBool()
        {
            if (_statement != null)
            {
                switch (_statement)
                {
                    case "has":
                    case "contains":
                        return Has(_expression.getString());
                }
                throw new OperatorException(
                    string.Format("Search term '{0}' cannot be applied operands of type 'bool'", _statement), Cursor);
            }
            return _expression.getBool();
        }

        /// <summary>
        /// Attempts to convert the string value to an integer.
        /// </summary>
        public override int getInt()
        {
            if (_statement != null)
            {
                throw new OperatorException(
                    string.Format("Statement '{0}' cannot be applied operands of type 'int'", _statement), Cursor);
            }
            return _expression.getInt();
        }

        /// <summary>
        /// Calculate the result of the expression and
        /// return it as a float value.
        /// </summary>
        public override float getPrecise()
        {
            if (_statement != null)
            {
                throw new OperatorException(
                    string.Format("Statement '{0}' cannot be applied operands of type 'precise'", _statement), Cursor);
            }
            return _expression.getPrecise();
        }

        /// <summary>
        /// Returns the float value as a string.
        /// </summary>
        public override string getString()
        {
            if (_statement != null)
            {
                throw new OperatorException(
                    string.Format("Statement '{0}' cannot be applied operands of type 'string'", _statement), Cursor);
            }
            return _expression.getString();
        }
    }
}