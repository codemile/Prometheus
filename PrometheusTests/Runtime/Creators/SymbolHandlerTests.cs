using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prometheus.Grammar;
using Prometheus.Runtime.Creators;
using PrometheusTest.Mock;

namespace PrometheusTest.Runtime.Creators
{
    [TestClass]
    public class SymbolHandlerTests
    {
        [TestMethod]
        public void SelectSymbolHandlers()
        {
            MethodInfo[] methods = SymbolHandler.SelectSymbolHandlers(typeof (MockCommand)).ToArray();

            Assert.AreEqual(1, methods.Length);
            Assert.AreEqual("Print", methods[0].Name);
        }

        [TestMethod]
        public void SymbolHandler_0()
        {
            SymbolHandler h = new SymbolHandler(GrammarSymbol.PrintCommand);
            Assert.AreEqual(GrammarSymbol.PrintCommand, h.Symbol);
        }

        [TestMethod]
        public void getSymbolHandler()
        {
            MethodInfo method = typeof (MockCommand).GetMethod("Print");

            SymbolHandler handler = SymbolHandler.getSymbolHandler(method);
            Assert.IsNotNull(handler);
            Assert.AreEqual(handler.Symbol, GrammarSymbol.PrintCommand);
        }
    }
}