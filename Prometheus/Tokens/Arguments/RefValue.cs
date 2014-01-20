using Markdown.Documents;

namespace Prometheus.Tokens.Arguments
{
    /// <summary>
    /// Holds a reference to a string value.
    /// </summary>
    public class RefValue : Ref
    {
        /// <summary>
        /// The string value.
        /// </summary>
        private string _value { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public RefValue(Context pContext, DocumentCursor pCursor, string pValue)
            : base(pContext, pCursor)
        {
            _value = pValue;
        }

        /// <summary>
        /// The string value.
        /// </summary>
        public override string getString()
        {
            return _value;
        }
    }
}