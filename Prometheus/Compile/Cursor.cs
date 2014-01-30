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
        public static readonly Cursor None = new Cursor();

        /// <summary>
        /// The column number.
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// The source for the source code.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The row number.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Use EMPTY if needed.
        /// </summary>
        private Cursor()
            : this(null, 0, 0)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Cursor(string pFileName, int pRow, int pColumn)
        {
            FileName = pFileName;
            Row = pRow;
            Column = pColumn;
        }

        /// <summary>
        /// Renders the location as a human readable value.
        /// </summary>
        public override string ToString()
        {
            return FileName == null
                ? "in undefined source."
                : string.Format("in {0} at: {1}, {2}", FileName, Row, Column);
        }
    }
}