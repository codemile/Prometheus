using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Storage;

namespace PrometheusTest.Mock.Types
{
    public class MockClosure : ClosureType
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MockClosure(InstanceType pThis, FunctionType pFunction)
            : base(pThis, pFunction)
        {
        }
    }
}