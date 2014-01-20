using Markdown.Documents;

namespace Prometheus.Tokens.Arguments
{
    /// <summary>
    /// Represents a reference to an object that produces a value.
    /// Like a string, variable or expression.
    /// </summary>
    public abstract class Ref : Argument
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected Ref(Context pContext, DocumentCursor pCursor)
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
        /// Attempts to convert the float value to an integer.
        /// </summary>
        public virtual int getInt()
        {
            return TypeConverter.getInt(getString());
        }

        /// <summary>
        /// Attempts to convert the string value to a float.
        /// </summary>
        public virtual float getPrecise()
        {
            return TypeConverter.getPrecise(getString());
        }

        /// <summary>
        /// For debugging.
        /// </summary>
        public override string ToString()
        {
            return GetType().Name;
        }

        /// <summary>
        /// Returns the value this reference points to.
        /// </summary>
        public abstract string getString();
    }
}