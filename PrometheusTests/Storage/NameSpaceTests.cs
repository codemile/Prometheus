using System.Collections.Generic;
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
        public void Add_0()
        {
            NameSpace ns = NameSpace.Create();
            ns.Declare(new QualifiedType("package"));
            Assert.IsTrue(ns.Add(new MockDeclaration(new QualifiedType("package"), new IdentifierType("x"))));
            Declaration decl = ns.Get(new QualifiedType("package.x"));
            Assert.IsNotNull(decl);
            Assert.AreEqual("x", decl.Identifier.Name);
        }

        [TestMethod]
        public void Add_1()
        {
            NameSpace ns = NameSpace.Create();
            Assert.IsTrue(ns.Add(new MockDeclaration(QualifiedType.Global, new IdentifierType("x"))));
            Declaration decl = ns.Get(new QualifiedType("global.x"));
            Assert.IsNotNull(decl);
            Assert.AreEqual("x", decl.Identifier.Name);
        }

        [TestMethod]
        public void Declare()
        {
            NameSpace ns = NameSpace.Create();
            Assert.IsTrue(ns.Declare(new QualifiedType("package.child")));
            Assert.IsTrue(ns.isPackage("package"));
            Assert.IsFalse(ns.isDeclaration("package"));
            NameSpace package = ns.Child("package");
            Assert.IsNotNull(package);
            Assert.IsTrue(package.isPackage("child"));
        }

        [TestMethod]
        public void Dispose()
        {
            QualifiedType package = new QualifiedType("package.child");
            NameSpace ns = NameSpace.Create();
            Assert.IsTrue(ns.Declare(package));
            Assert.IsTrue(ns.Add(new MockDeclaration(package, new IdentifierType("x"))));
            Assert.IsFalse(ns.isEmpty);
            ns.Dispose();
            Assert.IsTrue(ns.isEmpty);
        }

        [TestMethod]
        public void Get_IdentifierType_0()
        {
            NameSpace ns = NameSpace.Create();
            Assert.IsNull(ns.Get(new QualifiedType("global.x")));

            Assert.IsTrue(ns.Add(new MockDeclaration(QualifiedType.Global,new IdentifierType("x"))));
            Assert.IsFalse(ns.Add(new MockDeclaration(QualifiedType.Global, new IdentifierType("x"))));

            Declaration decl = ns.Get(new QualifiedType("global.x"));
            Assert.IsNotNull(decl);
            Assert.AreEqual("global", decl.NameSpace.FullName);
            Assert.AreEqual("x", decl.Identifier.Name);
        }

        [TestMethod]
        public void Get_QualifiedType_1()
        {
            NameSpace ns = NameSpace.Create();
            Assert.IsNull(ns.Get(new QualifiedType("x")));
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

            Assert.IsTrue(ns.Declare(new QualifiedType("package.child")));
            Assert.IsTrue(ns.Declare(new QualifiedType("package.above")));

            Assert.IsTrue(ns.Add(new MockDeclaration(QualifiedType.Global,new IdentifierType("x"))));
            Assert.IsTrue(ns.Add(new MockDeclaration(new QualifiedType("package"),new IdentifierType("y"))));
            Assert.IsTrue(ns.Add(new MockDeclaration(new QualifiedType("package.child"),new IdentifierType("z"))));

            ns.Print(ref lines);

            Assert.AreEqual(7, lines.Count);
            Assert.AreEqual("global:", lines[0]);
            Assert.AreEqual("global:x", lines[1]);
            Assert.AreEqual("package:", lines[2]);
            Assert.AreEqual("package:y", lines[3]);
            Assert.AreEqual("package.above:", lines[4]);
            Assert.AreEqual("package.child:", lines[5]);
            Assert.AreEqual("package.child:z", lines[6]);
        }
    }
}