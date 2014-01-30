using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prometheus.Grammar;
using Prometheus.Objects;
using PrometheusTest.Mock;

namespace PrometheusTest.Objects
{
    [TestClass]
    public class PrometheusObjectTests
    {
        [TestMethod]
        public void CreateMethodLookup()
        {
            Dictionary<GrammarSymbol, Dictionary<int, MethodInfo>> lookup = PrometheusObject.CreateMethodLookup(typeof(MockCommand));

            Assert.IsTrue(lookup.ContainsKey(GrammarSymbol.PrintCommand));
            Assert.IsTrue(lookup[GrammarSymbol.PrintCommand].ContainsKey(1));
            Assert.IsNotNull(lookup[GrammarSymbol.PrintCommand][1]);
        }

        [TestMethod]
        public void Execute()
        {

        }
    }
}
