using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prometheus.Tokens.Expressions;

namespace PrometheusTest.Tokens.Expressions
{
    /// <summary>
    /// Common code used to test expressions.
    /// </summary>
    public abstract class BaseExpressionTest : PrometheusTest
    {
        /// <summary>
        /// Creates both a bracketed and non-bracketed value.
        /// </summary>
        private static IEnumerable<string> BracketValue(string pValue)
        {
            List<string> brackets = new List<string>(2);
            // no brackets
            brackets.Add(string.Format("{0}", pValue));
            // brackets
            brackets.Add(string.Format("({0})", pValue));
            // brackets with spaces
            //brackets.Add(string.Format("( {0} )", pValue));
            // double brackets
            //brackets.Add(string.Format("(({0}))", pValue));
            return brackets;
        }

        /// <summary>
        /// Creates a list of possible two value operations for an expression.
        /// </summary>
        private static IEnumerable<string> ValOpVal(char pOperator)
        {
            // create of list of the values with brackets
            IEnumerable<string> bracketsA = BracketValue("{0}");
            IEnumerable<string> bracketsB = BracketValue("{1}");

            List<string> formulas = new List<string>();
            foreach (string valueA in bracketsA)
            {
                foreach (string valueB in bracketsB)
                {
                    // operator with spaces
                    formulas.Add(string.Format("{0} {1} {2}", valueA, pOperator, valueB));
                }
            }

            List<string> bracked = new List<string>();
            foreach (string forumula in formulas)
            {
                bracked.AddRange(BracketValue(forumula));
            }

            return bracked;
        }

        /// <summary>
        /// Executes a x+x test.
        /// </summary>
        protected static void ValOpValTest<T>(IEnumerable<ValOpValData<T>> pData, char pOperator) where T : struct
        {
            Type parameterType = typeof (T);

            BaseExpression exp;
            foreach (ValOpValData<T> x in pData)
            {
                foreach (string num_format in ValOpVal(pOperator))
                {
                    string str = string.Format(num_format, x.Left, x.Right);
                    exp = CreateAggRef<BaseExpression>(str);
                    if (parameterType == typeof (int))
                    {
                        Assert.AreEqual(x.Result, exp.getInt());
                    }
                    else if (parameterType == typeof (float))
                    {
                        Assert.AreEqual(x.Result, exp.getPrecise());
                    }
                    else
                    {
                        Assert.Fail("Unsupported type");
                    }
                }
            }
        }

        /// <summary>
        /// Test data for a x + x
        /// </summary>
        protected class ValOpValData<T>
        {
            public T Left { get; set; }
            public T Result { get; set; }
            public T Right { get; set; }
        }
    }
}