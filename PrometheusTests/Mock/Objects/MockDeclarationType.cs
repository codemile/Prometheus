using Prometheus.Nodes.Types;
using PrometheusTest.Mock.Types;

namespace PrometheusTest.Mock.Objects
{
    public class MockDeclarationType : DeclarationType
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MockDeclarationType()
            : base(null, new MockFunction())
        {
        }
    }
}