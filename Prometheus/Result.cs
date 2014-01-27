using Prometheus.Documents;
using Prometheus.Tokens.Commands;

namespace Prometheus
{
    /// <summary>
    /// Holds details about about finding text in the document.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// The command that found the match.
        /// </summary>
        private Command _finder { get; set; }

        /// <summary>
        /// If successful, this is the fragment that
        /// the match was found in.
        /// </summary>
        private Fragment _fragment { get; set; }

        /// <summary>
        /// Was a match made?
        /// </summary>
        private bool _success { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Result(bool pValue)
        {
            _success = pValue;
            _fragment = null;
        }

        /// <summary>
        /// Constructor for a successful match.
        /// </summary>
        public Result(Command pCommand, Fragment pFragment)
        {
            _success = true;
            _finder = pCommand;
            _fragment = pFragment;
        }
    }
}