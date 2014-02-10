using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prometheus.Nodes.Types;

namespace PrometheusTest.Nodes.Types
{
    [TestClass]
    public class IdentifierTests
    {
        [TestMethod]
        public void Identifier()
        {
            Identifier id = new Identifier("JOHN");
            Assert.AreEqual("john", id.Name);
        }

        [TestMethod]
        public void ToStringTest()
        {
            Identifier id = new Identifier("JOHN");
            Assert.AreEqual("john", id.ToString());
        }
    }
}