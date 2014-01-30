using Prometheus.Compile;
using Prometheus.Exceptions;
using Prometheus.Grammar;
using Prometheus.Objects;

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
            PrometheusStatement root = _objects.getObject(_code.Root) as PrometheusStatement;
            if (root == null)
            {
                //TODO: Replace with parser exception.
                throw new CompilerException("Unexpected null root object.", Cursor.None);
            }
            root.Execute(_code.Root);
        }
    }
}