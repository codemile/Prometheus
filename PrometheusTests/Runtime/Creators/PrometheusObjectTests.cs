using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prometheus.Grammar;
using Prometheus.Runtime.Creators;
using PrometheusTest.Mock;

namespace PrometheusTest.Runtime.Creators
{
    [TestClass]
    public class PrometheusObjectTests
    {
        [TestMethod]
        public void CreateMethodLookup()
        {
            Dictionary<GrammarSymbol, Dictionary<int, MethodInfo>> lookup =
                PrometheusObject.CreateMethodLookup(typeof (MockCommand));

            Assert.IsTrue(lookup.ContainsKey(GrammarSymbol.PrintProc));
            Assert.IsTrue(lookup[GrammarSymbol.PrintProc].ContainsKey(1));
            Assert.IsNotNull(lookup[GrammarSymbol.PrintProc][1]);
        }

        [TestMethod]
        public void Execute()
        {
        }
    }
}