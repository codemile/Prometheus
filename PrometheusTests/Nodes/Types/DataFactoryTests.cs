using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prometheus.Compile;
using Prometheus.Exceptions.Compiler;
using Prometheus.Grammar;
using Prometheus.Nodes.Types;

namespace PrometheusTest.Nodes.Types
{
    [TestClass]
    public class DataFactoryTests
    {
        private static readonly HashSet<GrammarSymbol> _dataTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.StringDouble,
                                                                        GrammarSymbol.StringSingle,
                                                                        GrammarSymbol.Number,
                                                                        GrammarSymbol.Decimal,
                                                                        GrammarSymbol.Boolean,
                                                                        GrammarSymbol.Identifier,
                                                                        GrammarSymbol.Type,
                                                                        GrammarSymbol.QualifiedID,
                                                                        GrammarSymbol.ValidID,
                                                                        GrammarSymbol.MemberName
                                                                    };

        private readonly Location _location = new Location("text.fire", "", 1, 1);

        [TestMethod]
        public void Create_0()
        {
            var items = new[]
                        {
                            new
                            {
                                Type = typeof (string),
                                Symbol = GrammarSymbol.StringDouble,
                                Str = "\"hello world\"",
                                Value = (object)"hello world"
                            },
                            new
                            {
                                Type = typeof (string),
                                Symbol = GrammarSymbol.StringSingle,
                                Str = "'hello world'",
                                Value = (object)"hello world"
                            },
                            new
                            {
                                Type = typeof (long),
                                Symbol = GrammarSymbol.Number,
                                Str = "3948",
                                Value = (object)(long)3948
                            },
                            new
                            {
                                Type = typeof (double),
                                Symbol = GrammarSymbol.Decimal,
                                Str = "48.23e+5",
                                Value = (object)48.23e+5
                            },
                            new
                            {
                                Type = typeof (bool),
                                Symbol = GrammarSymbol.Boolean,
                                Str = "true",
                                Value = (object)true
                            },
                            new
                            {
                                Type = typeof (bool),
                                Symbol = GrammarSymbol.Boolean,
                                Str = "false",
                                Value = (object)false
                            },
                            new
                            {
                                Type = typeof (bool),
                                Symbol = GrammarSymbol.Boolean,
                                Str = "yes",
                                Value = (object)true
                            },
                            new
                            {
                                Type = typeof (bool),
                                Symbol = GrammarSymbol.Boolean,
                                Str = "no",
                                Value = (object)false
                            },
                            new
                            {
                                Type = typeof (bool),
                                Symbol = GrammarSymbol.Boolean,
                                Str = "always",
                                Value = (object)true
                            },
                            new
                            {
                                Type = typeof (bool),
                                Symbol = GrammarSymbol.Boolean,
                                Str = "never",
                                Value = (object)false
                            }
                        };

            foreach (var item in items)
            {
                Data data = DataFactory.Create(_location, item.Symbol, item.Str);
                Assert.IsNotNull(data, item.Symbol.ToString());
                Assert.AreEqual(item.Type, data.Type, item.Symbol.ToString());

                object value = data.Get(item.Type);
                Assert.IsNotNull(value, item.Symbol.ToString());
                Assert.AreEqual(item.Value, value, item.Symbol.ToString());
            }
        }

        [TestMethod]
        [ExpectedException(typeof (UnsupportedDataTypeException))]
        public void Create_1()
        {
            DataFactory.Create(_location, GrammarSymbol.Statement, "");
        }

        [TestMethod]
        public void isDataType_0()
        {
            foreach (GrammarSymbol type in _dataTypes)
            {
                Assert.IsTrue(DataFactory.isDataType(type));
            }
        }

        [TestMethod]
        public void isDataType_1()
        {
            foreach (GrammarSymbol type in Enum.GetValues(typeof (GrammarSymbol)))
            {
                Assert.AreEqual(_dataTypes.Contains(type), DataFactory.isDataType(type));
            }
        }
    }
}