using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prometheus.Nodes.Types;

namespace PrometheusTest.Nodes.Types
{
    [TestClass]
    public class AliasTests
    {
        [TestMethod]
        public void Alias()
        {
            Alias a = new Alias(3);
            Assert.AreEqual(3, a.Heap);
        }

        [TestMethod]
        public void ToStringTest()
        {
            Alias a = new Alias(3);
            Assert.AreEqual("3", a.ToString());
        }
    }
}