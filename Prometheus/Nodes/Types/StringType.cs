using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    public class StringType : iDataType
    {
        public readonly string Value;

        public StringType(string pValue)
        {
            Value = pValue;
        }
    }
}