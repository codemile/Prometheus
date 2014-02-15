using Prometheus.Nodes;
using Prometheus.Nodes.Types;

namespace PrometheusTest.Mock.Types
{
    public class MockClosure : ClosureType
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MockClosure(AliasType pThis, Node pFunction)
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