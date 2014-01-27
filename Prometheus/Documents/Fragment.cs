namespace Prometheus.Documents
{
    /// <summary>
    /// Defines a fragment of text.
    /// </summary>
    public class Fragment
    {
        /// <summary>
        /// Fragment type for document titles.
        /// </summary>
        public const string BODY = "body";

        /// <summary>
        /// Fragment types for paragraphs.
        /// </summary>
        public const string PARAGRAPH = "paragraph";

        /// <summary>
        /// Fragment types for sentences.
        /// </summary>
        public const string SENTENCE = "sentence";

        /// <summary>
        /// Fragment type for document titles.
        /// </summary>
        public const string TITLE = "title";

        /// <summary>
        /// The text for this fragment.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// The name of the fragment (defined by the factory).
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Fragment(string pType, string pText)
        {
            Type = pType;
            Text = pText;
        }
    }
}