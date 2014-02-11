using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Storage;
using PrometheusTest.Mock.Types;

namespace PrometheusTest.Storage
{
    [TestClass]
    public class MemorySpaceTests
    {
        [TestMethod]
        public void Assign()
        {
            MemorySpace ms = new MemorySpace();
            Assert.IsFalse(ms.Has("x"));
            ms.Assign("x", new MockType("Hello World"));
            Assert.IsTrue(ms.Has("x"));

            MockType data = (MockType)ms.Get("x");
            Assert.AreEqual("Hello World",data.Value);
        }

        [TestMethod]
        public void Create()
        {
            MemorySpace ms = new MemorySpace();
            ms.Create("x", DataType.Undefined);
            Assert.IsTrue(ms.Has("x"));
        }

        [TestMethod]
        public void Dispose()
        {
            MemorySpace ms = new MemorySpace();
            ms.Create("x", DataType.Undefined);
            Assert.IsFalse(ms.isEmpty);
            ms.Dispose();
            Assert.IsTrue(ms.isEmpty);
        }

        [TestMethod]
        public void Get()
        {
            MemorySpace ms = new MemorySpace();
            ms.Create("x", DataType.Undefined);
            Assert.IsTrue(ms.Set("x", new MockType("Hello World")));
            MockType value = (MockType)ms.Get("x");
            Assert.IsNotNull(value);
            Assert.AreEqual("Hello World", value.Value);
        }

        [TestMethod]
        public void MemorySpace_0()
        {
            MemorySpace ms = new MemorySpace();
            Assert.IsTrue(ms.isEmpty);
        }

        [TestMethod]
        public void MemorySpace_1()
        {
            Dictionary<string, DataType> data = new Dictionary<string, DataType> {{"x", new MockType("Hello World")}};
            MemorySpace ms = new MemorySpace(data);
            Assert.IsFalse(ms.isEmpty);
        }

        [TestMethod]
        public void Print()
        {
        }

        [TestMethod]
        public void Set()
        {
            MemorySpace ms = new MemorySpace();
            Assert.IsFalse(ms.Set("x", new MockType("Hello World")));
            ms.Create("x", DataType.Undefined);
            Assert.IsTrue(ms.Set("x", new MockType("Hello World")));
        }

        [TestMethod]
        public void Unset()
        {
            MemorySpace ms = new MemorySpace();
            ms.Create("x", DataType.Undefined);
            Assert.IsTrue(ms.Has("x"));
            Assert.IsTrue(ms.Unset("x"));
            Assert.IsFalse(ms.Has("x"));
        }
    }
}