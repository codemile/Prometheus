using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;

namespace PrometheusTest.Nodes
{
    [TestClass]
    public class DataTypeFactoryTests
    {
        [TestMethod]
        public void Create()
        {
        }

        [TestMethod]
        public void CreateString_0()
        {
            StringType str = DataTypeFactory.CreateString("\"Hello World\"");
            Assert.AreEqual("Hello World", str.Value);
            Assert.AreEqual(StringType.eMODE.ANYWHERE, str.Mode);
        }

        [TestMethod]
        public void CreateString_1()
        {
            StringType str = DataTypeFactory.CreateString("'Hello World'");
            Assert.AreEqual("Hello World", str.Value);
            Assert.AreEqual(StringType.eMODE.WORD_BOUNDARIES, str.Mode);
        }

        [TestMethod]
        public void CreateString_2()
        {
            StringType str = DataTypeFactory.CreateString("''");
            Assert.AreEqual("", str.Value);
            Assert.AreEqual(StringType.eMODE.WORD_BOUNDARIES, str.Mode);
        }

        [TestMethod]
        public void CreateString_3()
        {
            StringType str = DataTypeFactory.CreateString("\"Hello\"i");
            Assert.AreEqual("Hello", str.Value);
            Assert.AreEqual(StringType.eMODE.ANYWHERE, str.Mode);
            Assert.AreEqual((int)StringType.eFLAGS.IGNORE_CASE, str.Flags);
        }

        [TestMethod]
        public void CreateString_4()
        {
            StringType str = DataTypeFactory.CreateString("\"Hello\"c");
            Assert.AreEqual("Hello", str.Value);
            Assert.AreEqual(StringType.eMODE.ANYWHERE, str.Mode);
            Assert.AreEqual((int)StringType.eFLAGS.NO_CACHING, str.Flags);
        }

        [TestMethod]
        public void CreateString_5()
        {
            StringType str = DataTypeFactory.CreateString("\"Hello\"f");
            Assert.AreEqual("Hello", str.Value);
            Assert.AreEqual(StringType.eMODE.ANYWHERE, str.Mode);
            Assert.AreEqual((int)StringType.eFLAGS.MATCH_FIRST, str.Flags);
        }

        [TestMethod]
        public void CreateString_6()
        {
            StringType str = DataTypeFactory.CreateString("\"Hello\"ic");
            Assert.AreEqual("Hello", str.Value);
            Assert.AreEqual(StringType.eMODE.ANYWHERE, str.Mode);
            Assert.AreEqual((int)StringType.eFLAGS.NO_CACHING
                            | (int)StringType.eFLAGS.IGNORE_CASE
                , str.Flags);
        }

        [TestMethod]
        public void CreateString_7()
        {
            StringType str = DataTypeFactory.CreateString("\"Hello\"icf");
            Assert.AreEqual("Hello", str.Value);
            Assert.AreEqual(StringType.eMODE.ANYWHERE, str.Mode);
            Assert.AreEqual((int)StringType.eFLAGS.MATCH_FIRST
                            | (int)StringType.eFLAGS.IGNORE_CASE
                            | (int)StringType.eFLAGS.NO_CACHING
                , str.Flags);
        }

        [TestMethod]
        public void isDataType()
        {
        }
    }
}