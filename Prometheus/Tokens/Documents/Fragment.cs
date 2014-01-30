namespace Prometheus.Tokens.Documents
{
    /// <summary>
    /// Defines a fragment of text.
    /// </summary>
    public class Fragment
    {
        /// <summary>
        /// The name of the fragment (defined by the factory).
        /// </summary>
        private readonly string _type;

        /// <summary>
        /// The text for this fragment.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Fragment(string pType, string pText)
        {
            _type = pType;
            Text = pText;
        }
    }
}