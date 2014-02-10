using Prometheus.Nodes.Types;

namespace PrometheusTest.Mock
{
    public static class MockAlias
    {
        public static Alias Create(int pHeap)
        {
            return new Alias(pHeap);
        }

        public static Alias Create()
        {
            return new Alias(3);
        }
    }
}