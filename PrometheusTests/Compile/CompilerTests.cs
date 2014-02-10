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
        public void Compile()
        {
            Compiler compiler = new Compiler();
            TargetCode target = compiler.Compile("test.txt", "var mathew=3;");
            Assert.IsNotNull(target.Root);
            Assert.AreEqual(GrammarSymbol.Declare, target.Root.Type);
            Assert.AreEqual(1, target.Root.Children.Count);
        }

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