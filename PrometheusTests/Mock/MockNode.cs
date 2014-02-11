using Prometheus.Grammar;
using Prometheus.Nodes;
using PrometheusTest.Mock.Compile;

namespace PrometheusTest.Mock
{
    public static class MockNode
    {
        public static Node Create()
        {
            return new Node(GrammarSymbol.Statement, new MockLocation());
        }

        public static Node Create(GrammarSymbol pSymbol)
        {
            return new Node(pSymbol, new MockLocation());
        }
    }
}