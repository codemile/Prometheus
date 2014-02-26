using Prometheus.Nodes.Types;

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