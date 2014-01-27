namespace Prometheus.Documents
{
    /// <summary>
    /// Represents a location in the source code. Used
    /// mostly for error reporting.
    /// </summary>
    public class DocumentCursor
    {
        /// <summary>
        /// An empty cursor
        /// </summary>
        public static readonly DocumentCursor None = new DocumentCursor();

        /// <summary>
        /// The column number.
        /// </summary>
        private int _column { get; set; }

        /// <summary>
        /// The source for the source code.
        /// </summary>
        private string _documentName { get; set; }

        /// <summary>
        /// The line number.
        /// </summary>
        private int _line { get; set; }

        /// <summary>
        /// Use EMPTY if needed.
        /// </summary>
        private DocumentCursor()
            : this(null, 0, 0)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public DocumentCursor(string pDocumentName, int pLine, int pColumn)
        {
            _documentName = pDocumentName;
            _line = pLine;
            _column = pColumn;
        }

        /// <summary>
        /// Renders the location as a human readable value.
        /// </summary>
        public override string ToString()
        {
            return _documentName == null
                ? "in undefined source."
                : string.Format("in {0} at: {1}, {2}", _documentName, _line, _column);
        }
    }
}