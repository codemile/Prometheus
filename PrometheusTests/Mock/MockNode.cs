using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types.Bases;
using PrometheusTest.Mock.Compile;

namespace PrometheusTest.Mock
{
    public static class MockNode
    {
        public static Node Create()
        {
            return new Node(GrammarSymbol.Statement, new MockLocation());
        }

        public static Node Create(DataType pData)
        {
            Node node = Create();
            node.Data.Add(pData);
            return node;
        }

        public static Node Create(GrammarSymbol pSymbol)
        {
            return new Node(pSymbol, new MockLocation());
        }

        public static Node Create(GrammarSymbol pSymbol, DataType pData)
        {
            Node node = Create(pSymbol);
            node.Data.Add(pData);
            return node;
        }

        public static Node Create(GrammarSymbol pSymbol, IEnumerable<DataType> pDatas)
        {
            Node node = Create(pSymbol);
            node.Data.AddRange(pDatas);
            return node;
        }
    }
}