using Prometheus.Nodes.Types;
using Prometheus.Parser.Executors;
using Prometheus.Parser.Executors.Attributes;

namespace Prometheus.Runtime
{
    /// <summary>
    /// All the string functions
    /// </summary>
    public class StringManipulation : ExecutorInternal
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
        [ExecuteInternal("lower")]
        public Data Lower(Data pValue)
        {
            return new Data(pValue.getString().ToLower());
        }

        /// <summary>
        /// Converts to trims spaces
        /// </summary>
        [ExecuteInternal("trim")]
        public Data Trim(Data pValue)
        {
            return new Data(pValue.getString().Trim());
        }

        /// <summary>
        /// Converts to upper case.
        /// </summary>
        [ExecuteInternal("upper")]
        public Data Upper(Data pValue)
        {
            return new Data(pValue.getString().ToUpper());
        }
    }
}