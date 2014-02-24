using Prometheus.Nodes.Types;

namespace PrometheusTest.Mock.Types
{
    public class MockFunction : FunctionType
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MockFunction()
            : base(MockNode.Create())
        {
        }
    }
}