namespace Prometheus.Nodes
{
    /// <summary>
    /// Methods to procedurally build regular expressions.
    /// </summary>
    public static class RegexFactory
    {
        /// <summary>
        /// What it can't start with or end with
        /// </summary>
        private const string _AFTER = @"(?!\w)";

        /// <summary>
        /// What it can't start with or end with
        /// </summary>
        private const string _BEFORE = @"(?<!\w)";

        /// <summary>
        /// Wraps a regex in look around that force the word to be
        /// surrounded by spaces or start/end of a line.
        /// </summary>
        /// <param name="pWord"></param>
        /// <returns></returns>
        public static string WordBoundaries(string pWord)
        {
            return "(" + _BEFORE + pWord + _AFTER + ")";
        }
    }
}