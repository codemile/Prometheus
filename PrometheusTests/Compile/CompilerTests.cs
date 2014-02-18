using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prometheus.Compile;
using Prometheus.Grammar;

namespace PrometheusTest.Compile
{
    [TestClass]
    public class CompilerTests
    {
        [TestMethod]
        public void Compiler()
        {
            try
            {
                Compiler compiler = new Compiler();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}