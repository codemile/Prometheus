using Prometheus.Compile;
using Prometheus.Compile.Packaging;

namespace PrometheusTest.Mock.Compile
{
    public class MockLocation : Location
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MockLocation()
            : base(new Imported("source.fire", "Source"), "MockLocation", 0, 0)
        {
        }
    }
}