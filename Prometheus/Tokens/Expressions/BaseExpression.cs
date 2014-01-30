using System.Globalization;
using Prometheus.Compile;
using Prometheus.Tokens.Arguments;

namespace Prometheus.Tokens.Expressions
{
    /// <summary>
    /// A base implement for math expressions
    /// </summary>
    public abstract class BaseExpression : Token
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseExpression(Context pContext, Cursor pCursor)
            : base(pContext, pCursor)
        {
        }

        /// <summary>
        /// Attempts to convert the string value to a boolean.
        /// </summary>
        public virtual bool getBool()
        {
            return TypeConverter.getBool(getString());
        }

        /// <summary>
        /// Attempts to convert the string value to an integer.
        /// </summary>
        public virtual int getInt()
        {
            return TypeConverter.getInt(getString());
        }

        /// <summary>
        /// Returns the float value as a string.
        /// </summary>
        public virtual string getString()
        {
            return getPrecise().ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Calculate the result of the expression and
        /// return it as a float value.
        /// </summary>
        public abstract float getPrecise();
    }
}