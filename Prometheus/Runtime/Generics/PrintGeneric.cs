using Logging;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Parser.Executors;
using Prometheus.Parser.Executors.Attributes;

namespace Prometheus.Runtime.Generics
{
    /// <summary>
    /// Prints a string to the output.
    /// </summary>
    public class PrintGeneric : ExecutorGeneric
    {
        /// <summary>
        /// Logging
        /// </summary>
        private static readonly Logger _logger = Logger.Create(typeof (PrintGeneric));

        /// <summary>
        /// Constructor
        /// </summary>
        public PrintGeneric(Executor pExecutor)
            : base(pExecutor)
        {
        }

        /// <summary>
        /// Prints a string to the output.
        /// </summary>
        /// <param name="pValue">The message to print.</param>
        [ExecuteGeneric("print")]
        public DataType Print(DataType pValue)
        {
            QualifiedType id = pValue as QualifiedType;

            DataType value = id != null
                ? Executor.Cursor.Resolve(id).Read()
                : pValue;

            _logger.Fine(value.ToString());

            return UndefinedType.Undefined;
        }
    }
}