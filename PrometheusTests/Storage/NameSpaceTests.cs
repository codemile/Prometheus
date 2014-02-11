using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prometheus.Nodes.Types;
using Prometheus.Objects;
using Prometheus.Storage;
using PrometheusTest.Mock.Objects;

namespace PrometheusTest.Storage
{
    [TestClass]
    public class NameSpaceTests
    {
        [TestMethod]
        public void Add()
        {
            NameSpace ns = NameSpace.Create();
            Assert.IsTrue(ns.Add(new MockDeclaration(new IdentifierType("x"))));
            Declaration decl = ns.Get(new IdentifierType("x"));
            Assert.IsNotNull(decl);
            Assert.AreEqual("x", decl.Identifier.FullName);
        }

        [TestMethod]
        public void Dispose()
        {
            NameSpace ns = NameSpace.Create();
            Assert.IsTrue(ns.Declare(new IdentifierType("package.child")));
            Assert.IsTrue(ns.Add(new MockDeclaration(new IdentifierType("package.child.x"))));
            Assert.IsTrue(ns.Add(new MockDeclaration(new IdentifierType("package.child.y"))));
            Assert.IsTrue(ns.Add(new MockDeclaration(new IdentifierType("package.child.z"))));
            Assert.IsFalse(ns.isEmpty);
            ns.Dispose();
            Assert.IsTrue(ns.isEmpty);
        }

        [TestMethod]
        public void Declare()
        {
            NameSpace ns = NameSpace.Create();
            Assert.IsTrue(ns.Declare(new IdentifierType("package.child")));
            Assert.IsTrue(ns.isPackage("package"));
            Assert.IsFalse(ns.isDeclaration("package"));
            NameSpace package = ns.Child("package");
            Assert.IsNotNull(package);
            Assert.IsTrue(package.isPackage("child"));
        }

        [TestMethod]
        public void Get_IdentifierType0()
        {
            NameSpace ns = NameSpace.Create();
            Assert.IsNull(ns.Get(new IdentifierType("x")));

            Assert.IsTrue(ns.Add(new MockDeclaration(new IdentifierType("x"))));
            Assert.IsFalse(ns.Add(new MockDeclaration(new IdentifierType("x"))));

            Declaration decl = ns.Get(new IdentifierType("x"));
            Assert.IsNotNull(decl);
            Assert.AreEqual("x",decl.Identifier.FullName);
        }

        [TestMethod]
        public void Get_QualifiedType()
        {
            NameSpace ns = NameSpace.Create();
            Assert.IsNull(ns.Get(new QualifiedType(new[]{"x"})));
        }

        [TestMethod]
        public void NameSpace_0()
        {
            NameSpace ns = NameSpace.Create();
            Assert.IsTrue(ns.isPackage("global"));
        }

        [TestMethod]
        public void Print()
        {
            List<string> lines = new List<string>();
            NameSpace ns = NameSpace.Create();

            Assert.IsTrue(ns.Declare(new IdentifierType("package.child")));
            Assert.IsTrue(ns.Declare(new IdentifierType("package.above")));

            Assert.IsTrue(ns.Add(new MockDeclaration(new IdentifierType("x"))));
            Assert.IsTrue(ns.Add(new MockDeclaration(new IdentifierType("package.y"))));
            Assert.IsTrue(ns.Add(new MockDeclaration(new IdentifierType("package.child.z"))));

            ns.Print(ref lines);

            Assert.AreEqual(7,lines.Count);
            Assert.AreEqual(":x", lines[0]);
            Assert.AreEqual("global:", lines[1]);
            Assert.AreEqual("package:", lines[2]);
            Assert.AreEqual("package:y", lines[3]);
            Assert.AreEqual("package.above:", lines[4]);
            Assert.AreEqual("package.child:", lines[5]);
            Assert.AreEqual("package.child:z", lines[6]);
        }
    }
}