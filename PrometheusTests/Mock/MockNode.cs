using Prometheus.Compile;
using Prometheus.Grammar;
using Prometheus.Nodes;

namespace PrometheusTest.Mock
{
    public static class MockNode
    {
        public static Node Create()
        {
            return new Node(GrammarSymbol.Statement, new Location("test.fire", "set mathew=3;", 1, 1));
        }

        public static Node Create(GrammarSymbol pSymbol)
        {
            return new Node(pSymbol, new Location("test.fire", "set mathew=3;", 1, 1));
        }
    }
}