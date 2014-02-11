using Prometheus.Nodes.Types;
using Prometheus.Objects;

namespace PrometheusTest.Mock.Objects
{
    public class MockDeclaration : Declaration
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MockDeclaration(QualifiedType pNameSpace, IdentifierType pName)
            : base(new ClassNameType(pNameSpace, pName), null, MockNode.Create())
        {
        }
    }
}