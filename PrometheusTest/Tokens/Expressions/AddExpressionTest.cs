using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrometheusTest.Tokens.Expressions
{
    [TestClass]
    public class AddExpressionTest : BaseExpressionTest
    {
        [TestMethod]
        public void Test_Add_Float()
        {
            List<ValOpValData<float>> data = new List<ValOpValData<float>>();
            for (float i = 1.0f; i < 10.0f; i = i + 1.0f)
            {
                data.Add(new ValOpValData<float> {Result = 10.0f - i + i, Left = 10.0f - i, Right = i});
            }
            ValOpValTest(data, '+');
        }

        [TestMethod]
        public void Test_Add_Int()
        {
            List<ValOpValData<int>> data = new List<ValOpValData<int>>();
            for (int i = 1; i < 10; i++)
            {
                data.Add(new ValOpValData<int> {Result = 10 - i + i, Left = 10 - i, Right = i});
            }
            ValOpValTest(data, '+');
        }
    }
}