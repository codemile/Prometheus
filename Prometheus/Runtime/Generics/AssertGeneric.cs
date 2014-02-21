using Prometheus.Exceptions.Executor;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Parser.Executors;
using Prometheus.Parser.Executors.Attributes;

namespace Prometheus.Runtime.Generics
{
    /// <summary>
    /// Commands related to testing.
    /// </summary>
    public class AssertGeneric : ExecutorGeneric
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AssertGeneric(Executor pExecutor)
            : base(pExecutor)
        {
        }

        /// <summary>
        /// Handles a basic assert
        /// </summary>
        [ExecuteGeneric("assert")]
        public DataType _Assert(DataType pValue)
        {
            if (!pValue.getBool())
            {
                throw new AssertionException("Assert failed", Executor.Cursor.Node);
            }
            return UndefinedType.Undefined;
        }
    }
}