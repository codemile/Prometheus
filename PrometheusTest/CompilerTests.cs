using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prometheus;

namespace PrometheusTest
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

        [TestMethod]
        public void Compile()
        {
            Compiler compiler = new Compiler();
            Node node = compiler.Compile("test.txt", "set mathew= 3 + (john);");
            Assert.IsNotNull(node);
        }
    }
}