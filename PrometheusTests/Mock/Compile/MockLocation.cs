using Prometheus.Compile;

namespace PrometheusTest.Mock.Compile
{
    public class MockLocation : Location
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MockLocation()
            : base("source.fire", "MockLocation", 0, 0)
        {
        }
    }
}