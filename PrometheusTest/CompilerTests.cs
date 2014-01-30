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
            TargetCode target = compiler.Compile("test.txt", "set mathew=3");
            Assert.IsNotNull(target.Root);
            Assert.AreEqual(ParserSymbol.SetCommand, target.Root.Type);
            Assert.AreEqual(2, target.Root.Children.Count);
        }
    }
}