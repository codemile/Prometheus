using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Storage;
using PrometheusTest.Mock.Types;

namespace PrometheusTest.Storage
{
    [TestClass]
    public class StorageSpaceTests
    {
        [TestMethod]
        public void Assign()
        {
            StorageSpace ms = new StorageSpace();
            Assert.IsFalse(ms.Has("x"));
            ms.Assign("x", new MockType("Hello World"));
            Assert.IsTrue(ms.Has("x"));

            MockType data = (MockType)ms.Get("x");
            Assert.AreEqual("Hello World", data.Value);
        }

        [TestMethod]
        public void Create()
        {
            StorageSpace ms = new StorageSpace();
            ms.Create("x", UndefinedType.Undefined);
            Assert.IsTrue(ms.Has("x"));
        }

        [TestMethod]
        public void Dispose()
        {
            StorageSpace ms = new StorageSpace();
            ms.Create("x", UndefinedType.Undefined);
            Assert.IsFalse(ms.isEmpty);
            ms.Dispose();
            Assert.IsTrue(ms.isEmpty);
        }

        [TestMethod]
        public void Get()
        {
            StorageSpace ms = new StorageSpace();
            ms.Create("x", UndefinedType.Undefined);
            Assert.IsTrue(ms.Set("x", new MockType("Hello World")));
            MockType value = (MockType)ms.Get("x");
            Assert.IsNotNull(value);
            Assert.AreEqual("Hello World", value.Value);
        }

        [TestMethod]
        public void MemorySpace_0()
        {
            StorageSpace ms = new StorageSpace();
            Assert.IsTrue(ms.isEmpty);
        }

        [TestMethod]
        public void MemorySpace_1()
        {
            Dictionary<string, DataType> data = new Dictionary<string, DataType> {{"x", new MockType("Hello World")}};
            StorageSpace ms = new StorageSpace(data);
            Assert.IsFalse(ms.isEmpty);
        }

        [TestMethod]
        public void Print()
        {
        }

        [TestMethod]
        public void Set()
        {
            StorageSpace ms = new StorageSpace();
            Assert.IsFalse(ms.Set("x", new MockType("Hello World")));
            ms.Create("x", UndefinedType.Undefined);
            Assert.IsTrue(ms.Set("x", new MockType("Hello World")));
        }

        [TestMethod]
        public void Unset()
        {
            StorageSpace ms = new StorageSpace();
            ms.Create("x", UndefinedType.Undefined);
            Assert.IsTrue(ms.Has("x"));
            Assert.IsTrue(ms.Unset("x"));
            Assert.IsFalse(ms.Has("x"));
        }
    }
}