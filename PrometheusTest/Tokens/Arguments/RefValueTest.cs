using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prometheus.Tokens.Expressions;

namespace PrometheusTest.Tokens.Arguments
{
    [TestClass]
    public class RefValueTest : BaseArgumentTest
    {
        /// <summary>
        /// Test literal boolean value
        /// </summary>
        [TestMethod]
        public void Test_Bool()
        {
            BaseExpression _ref = CreateAggRef<BaseExpression>("true");
            Assert.AreEqual(true, _ref.getBool());

            _ref = CreateAggRef<BaseExpression>("false");
            Assert.AreEqual(false, _ref.getBool());
        }

        /// <summary>
        /// Test literal float value
        /// </summary>
        [TestMethod]
        public void Test_Float()
        {
            BaseExpression _ref = CreateAggRef<BaseExpression>("1.234");
            Assert.AreEqual(1.234f, _ref.getPrecise());

            _ref = CreateAggRef<BaseExpression>("39.47");
            Assert.AreEqual(39.47f, _ref.getPrecise());

            _ref = CreateAggRef<BaseExpression>("-3,492.39");
            Assert.AreEqual(-3492.39f, _ref.getPrecise());

            _ref = CreateAggRef<BaseExpression>("0");
            Assert.AreEqual(0.0f, _ref.getPrecise());
        }

        /// <summary>
        /// Test literal int value
        /// </summary>
        [TestMethod]
        public void Test_Int()
        {
            BaseExpression _ref = CreateAggRef<BaseExpression>("3489.309");
            Assert.AreEqual(3489, _ref.getInt());

            _ref = CreateAggRef<BaseExpression>("0.0");
            Assert.AreEqual(0, _ref.getInt());

            _ref = CreateAggRef<BaseExpression>("38,390.0");
            Assert.AreEqual(38390, _ref.getInt());

            _ref = CreateAggRef<BaseExpression>("-30,204.29");
            Assert.AreEqual(-30204, _ref.getInt());
        }

        /// <summary>
        /// Test the usage of a string as a boolean
        /// </summary>
        [TestMethod]
        public void Test_String_Bool()
        {
            BaseExpression _ref = CreateAggRef<BaseExpression>("'$1,129.27'");
            Assert.AreEqual(true, _ref.getBool());

            _ref = CreateAggRef<BaseExpression>("'0.0'");
            Assert.AreEqual(false, _ref.getBool());

            _ref = CreateAggRef<BaseExpression>("'on'");
            Assert.AreEqual(true, _ref.getBool());

            _ref = CreateAggRef<BaseExpression>("'false'");
            Assert.AreEqual(false, _ref.getBool());
        }

        /// <summary>
        /// Test the usage of double quotes for strings.
        /// </summary>
        [TestMethod]
        public void Test_String_DoubleQuotes()
        {
            BaseExpression _ref = CreateAggRef<BaseExpression>("\"abcdef\"");
            Assert.AreEqual("abcdef", _ref.getString());
        }

        /// <summary>
        /// Test the usage of a string as a float
        /// </summary>
        [TestMethod]
        public void Test_String_Float()
        {
            BaseExpression _ref = CreateAggRef<BaseExpression>("'1.234'");
            Assert.AreEqual(1.234f, _ref.getPrecise());

            _ref = CreateAggRef<BaseExpression>("'$39.47'");
            Assert.AreEqual(39.47f, _ref.getPrecise());

            _ref = CreateAggRef<BaseExpression>("'  3,492.39  '");
            Assert.AreEqual(3492.39f, _ref.getPrecise());

            _ref = CreateAggRef<BaseExpression>("'0'");
            Assert.AreEqual(0.0f, _ref.getPrecise());
        }

        /// <summary>
        /// Test the usage of a string as a integer
        /// </summary>
        [TestMethod]
        public void Test_String_Int()
        {
            BaseExpression _ref = CreateAggRef<BaseExpression>("'3489.309'");
            Assert.AreEqual(3489, _ref.getInt());

            _ref = CreateAggRef<BaseExpression>("'0.0'");
            Assert.AreEqual(0, _ref.getInt());

            _ref = CreateAggRef<BaseExpression>("'38,390.0'");
            Assert.AreEqual(38390, _ref.getInt());

            _ref = CreateAggRef<BaseExpression>("'$-30,204.29'");
            Assert.AreEqual(-30204, _ref.getInt());
        }

        /// <summary>
        /// Test the usage of single quotes for strings.
        /// </summary>
        [TestMethod]
        public void Test_String_SingleQuotes()
        {
            BaseExpression _ref = CreateAggRef<BaseExpression>("'abcdef'");
            Assert.AreEqual("abcdef", _ref.getString());
        }
    }
}