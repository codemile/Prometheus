using Prometheus.Nodes.Types.Bases;

namespace PrometheusTest.Mock.Types
{
    public class MockType : DataType
    {
        public readonly string Value;

        public MockType(string pValue)
        {
            Value = pValue;
        }
    }
}