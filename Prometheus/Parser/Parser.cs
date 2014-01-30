using Prometheus.Compile;
using Prometheus.Grammar;

namespace Prometheus.Parser
{
    /// <summary>
    /// The run-time engine for Prometheus.
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// The compiled code
        /// </summary>
        private readonly TargetCode _code;

        /// <summary>
        /// The executable objects.
        /// </summary>
        private readonly GrammarObject _objects;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pCode">The compiled code to parse.</param>
        public Parser(TargetCode pCode)
        {
            _code = pCode;
            _objects = new GrammarObject();
        }

        /// <summary>
        /// Executes the code
        /// </summary>
        public void Execute()
        {
            _objects.Dispatch(_code.Root);
        }
    }
}