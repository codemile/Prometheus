using Prometheus.Nodes.Types;
using Prometheus.Objects;

namespace PrometheusTest.Mock.Objects
{
    public class MockDeclaration : Declaration
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MockDeclaration(IdentifierType pIdentifier)
            : base(null, pIdentifier, MockNode.Create())
        {
        }
    }
}