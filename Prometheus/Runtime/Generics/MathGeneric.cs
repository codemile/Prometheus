using Prometheus.Parser.Executors;

namespace Prometheus.Runtime.Generics
{
    public class MathGeneric : ExecutorGeneric
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MathGeneric(Executor pExecutor)
            : base(pExecutor)
        {
        }
    }
}