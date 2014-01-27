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
        private string _fileName { get; set; }

        /// <summary>
        /// The row number.
        /// </summary>
        private int _row { get; set; }

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
        public DocumentCursor(string pFileName, int pRow, int pColumn)
        {
            _fileName = pFileName;
            _row = pRow;
            _column = pColumn;
        }

        /// <summary>
        /// Renders the location as a human readable value.
        /// </summary>
        public override string ToString()
        {
            return _fileName == null
                ? "in undefined source."
                : string.Format("in {0} at: {1}, {2}", _fileName, _row, _column);
        }
    }
}