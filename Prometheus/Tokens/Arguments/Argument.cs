using Prometheus.Compile;

namespace Prometheus.Tokens.Arguments
{
    /// <summary>
    /// All objects that are passed around as arguments.
    /// </summary>
    public abstract class Argument : Token
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected Argument(Context pContext, Cursor pCursor)
            : base(pContext, pCursor)
        {
        }
    }
}