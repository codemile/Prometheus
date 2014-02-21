using Prometheus.Nodes.Types;
using Prometheus.Parser.Executors;
using Prometheus.Parser.Executors.Attributes;

namespace Prometheus.Runtime
{
    /// <summary>
    /// All the string functions
    /// </summary>
    public class StringManipulation : ExecutorGeneric
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public StringManipulation(Executor pExecutor)
            : base(pExecutor)
        {
        }

        /// <summary>
        /// Converts to lower case.
        /// </summary>
        [ExecuteGeneric("lower")]
        public StringType Lower(StringType pValue)
        {
            return new StringType(pValue.Value.ToLower());
        }

        /// <summary>
        /// Converts to trims spaces
        /// </summary>
        [ExecuteGeneric("trim")]
        public StringType Trim(StringType pValue)
        {
            return new StringType(pValue.Value.Trim());
        }

        /// <summary>
        /// Converts to upper case.
        /// </summary>
        [ExecuteGeneric("upper")]
        public StringType Upper(StringType pValue)
        {
            return new StringType(pValue.Value.ToUpper());
        }
    }
}