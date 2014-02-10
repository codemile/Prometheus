using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    public class BooleanType : iDataType
    {
        public readonly bool Value;

        public BooleanType(bool pValue)
        {
            Value = pValue;
        }
    }
}