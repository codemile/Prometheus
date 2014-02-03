using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prometheus.Nodes.Types;

namespace PrometheusTest.Nodes
{
    [TestClass]
    public class DataConverterTests
    {
        [TestMethod]
        public void BestNumericType()
        {
            Assert.AreEqual(typeof (long), DataConverter.BestNumericType(typeof (long), typeof (long)));
            Assert.AreEqual(typeof (double), DataConverter.BestNumericType(typeof (double), typeof (long)));
            Assert.AreEqual(typeof (double), DataConverter.BestNumericType(typeof (long), typeof (double)));
            Assert.AreEqual(typeof (double), DataConverter.BestNumericType(typeof (double), typeof (double)));
        }
    }
}