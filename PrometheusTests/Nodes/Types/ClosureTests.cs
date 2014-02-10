using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prometheus.Nodes.Types;
using PrometheusTest.Mock;

namespace PrometheusTest.Nodes.Types
{
    [TestClass]
    public class ClosureTests
    {
        [TestMethod]
        public void Closure()
        {
            Closure c = new Closure(MockAlias.Create(), MockNode.Create());
            Assert.AreEqual(typeof (Alias), c.This.Heap);
            Assert.IsNotNull(c.Function);
        }
    }
}