using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prometheus.Tokens.Expressions;

namespace PrometheusTest.Tokens.Expressions
{
    [TestClass]
    public class UnaryOperatorTest : PrometheusTest
    {
        [TestMethod]
        public void Test_Unary_Boolean()
        {
            List<KeyValuePair<bool, string>> data = new List<KeyValuePair<bool, string>>
                                                    {
                                                        new KeyValuePair<bool, string>(true, "true"),
                                                        new KeyValuePair<bool, string>(false, "false"),
                                                        new KeyValuePair<bool, string>(false, "!true"),
                                                        new KeyValuePair<bool, string>(true, "!false"),
                                                        new KeyValuePair<bool, string>(true, "on"),
                                                        new KeyValuePair<bool, string>(false, "off"),
                                                        new KeyValuePair<bool, string>(false, "!on"),
                                                        new KeyValuePair<bool, string>(true, "!off"),
                                                        new KeyValuePair<bool, string>(false, "not true"),
                                                        new KeyValuePair<bool, string>(true, "not false")
                                                    };

            foreach (KeyValuePair<bool, string> pair in data)
            {
                BaseExpression neg = createAggRef<BaseExpression>(pair.Value);
                Assert.AreEqual(pair.Key, neg.getBool());
            }
        }

        [TestMethod]
        public void Test_Unary_Float()
        {
            List<KeyValuePair<float, string>> data = new List<KeyValuePair<float, string>>
                                                     {
                                                         new KeyValuePair<float, string>(-10.0f, "-10"),
                                                         new KeyValuePair<float, string>(+10.0f, "+10")
                                                     };
            foreach (KeyValuePair<float, string> pair in data)
            {
                BaseExpression neg = createAggRef<BaseExpression>(pair.Value);
                Assert.AreEqual(pair.Key, neg.getPrecise());
            }
        }

        [TestMethod]
        public void Test_Unary_Int()
        {
            List<KeyValuePair<int, string>> data = new List<KeyValuePair<int, string>>
                                                   {
                                                       new KeyValuePair<int, string>(-10, "-10"),
                                                       new KeyValuePair<int, string>(+10, "+10"),
                                                       new KeyValuePair<int, string>(~10, "~10")
                                                   };
            foreach (KeyValuePair<int, string> pair in data)
            {
                BaseExpression neg = createAggRef<BaseExpression>(pair.Value);
                Assert.AreEqual(pair.Key, neg.getInt());
            }
        }
    }
}