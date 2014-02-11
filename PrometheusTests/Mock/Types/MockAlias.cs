using Prometheus.Nodes.Types;

namespace PrometheusTest.Mock.Types
{
    public static class MockAlias
    {
        public static AliasType Create(int pHeap)
        {
            return new AliasType(pHeap);
        }

        public static AliasType Create()
        {
            return new AliasType(3);
        }
    }
}