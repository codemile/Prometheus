namespace Prometheus.Compile
{
    /// <summary>
    /// Represents a location in the source code.
    /// Used mostly for error reporting.
    /// </summary>
    public class Cursor
    {
        /// <summary>
        /// An empty cursor
        /// </summary>
        public static readonly Cursor None = new Cursor(null, 0, 0);

        /// <summary>
        /// The column number.
        /// </summary>
        private readonly int _column;

        /// <summary>
        /// The source for the source code.
        /// </summary>
        private readonly string _fileName;

        /// <summary>
        /// The row number.
        /// </summary>
        private readonly int _row;

        /// <summary>
        /// Constructor
        /// </summary>
        public Cursor(string pFileName, int pRow, int pColumn)
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