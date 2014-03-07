using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Storage;

namespace PrometheusTest.Mock.Types
{
    public class MockClosure : ClosureType
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MockClosure(InstanceType pThis, FunctionType pFunction)
            : base(pThis, new DataType[0], new StorageSpace(),  pFunction.Entry)
        {
        }
    }
}