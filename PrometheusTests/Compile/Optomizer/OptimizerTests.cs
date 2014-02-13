using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prometheus.Compile;
using Prometheus.Compile.Optomizer;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using PrometheusTest.Mock;
using PrometheusTest.Mock.Types;

namespace PrometheusTest.Compile.Optomizer
{
    [TestClass]
    public class OptimizerTests
    {
        [TestMethod]
        public void CallInternal()
        {
        }

        [TestMethod]
        public void ClassName()
        {
        }

        [TestMethod]
        public void Optimize()
        {
        }

        [TestMethod]
        public void OptimizeNode()
        {
        }

        [TestMethod]
        public void Qualify()
        {
            Node node = MockNode.Create(GrammarSymbol.QualifiedID);
            node.Add(MockNode.Create(GrammarSymbol.ValidID, new IdentifierType("options")));
            node.Add(
                MockNode.Create(GrammarSymbol.MemberList, new IdentifierType("debug"))
                .Add(MockNode.Create(GrammarSymbol.MemberList)));

            Optimizer.Qualify(node);
            node.Reduce();

            Assert.AreEqual(0,node.Children.Count);
            Assert.AreEqual(1,node.Data.Count);

            QualifiedType q = node.Data[0] as QualifiedType;
            Assert.IsNotNull(q);

            Assert.AreEqual("options.debug", q.FullName);
            Assert.AreEqual("debug", q.Name);
        }

        [TestMethod]
        public void ShiftData()
        {
            Node parent = MockNode.Create();
            Node child = MockNode.Create(new MockType("Hello World"));

            Optimizer.ShiftData(parent,child);

            Assert.AreEqual(0,child.Data.Count);
            Assert.AreEqual(1, parent.Data.Count);
            Assert.AreEqual("Hello World", ((MockType)parent.Data[0]).Value);
        }

        [TestMethod]
        public void WalkBranch()
        {
        }
    }
}