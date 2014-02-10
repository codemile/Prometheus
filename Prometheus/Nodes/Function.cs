using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes
{
    /// <summary>
    /// An uninitialized closure function
    /// </summary>
    public class Function : iDataType
    {
        public readonly Node Func;

        public Function(Node pFunc)
        {
            Func = pFunc;
        }
    }
}