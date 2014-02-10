using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
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
        public DataType Lower(DataType pValue)
        {
            return new DataType(pValue.getString().ToLower());
        }

        /// <summary>
        /// Converts to trims spaces
        /// </summary>
        [ExecuteInternal("trim")]
        public DataType Trim(DataType pValue)
        {
            return new DataType(pValue.getString().Trim());
        }

        /// <summary>
        /// Converts to upper case.
        /// </summary>
        [ExecuteInternal("upper")]
        public DataType Upper(DataType pValue)
        {
            return new DataType(pValue.getString().ToUpper());
        }
    }
}