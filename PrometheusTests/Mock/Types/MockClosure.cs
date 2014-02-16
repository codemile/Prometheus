using Prometheus.Nodes;
using Prometheus.Nodes.Types;

namespace PrometheusTest.Mock.Types
{
    public class MockClosure : ClosureType
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MockClosure(InstanceType pThis, ClosureType pFunction)
            : base(pThis, pFunction)
        {
        }

        /// <summary>
        /// Un-compiled closure
        /// </summary>
        public MockClosure(Node pFunction)
            : base(pFunction)
        {
        }

        public MockClosure()
            : this(MockNode.Create())
        {
        }
    }
}