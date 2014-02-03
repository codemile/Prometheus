using System.Collections.Generic;
using Prometheus.Compile;
using Prometheus.Executors;
using Prometheus.Nodes.Types;

namespace Prometheus.Parser
{
    /// <summary>
    /// The run-time engine for Prometheus.
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// Runs the code
        /// </summary>
        public static int Run(TargetCode pCode)
        {
            Executor executor = new Executor();
            Data value = executor.Execute(pCode.Root, new Dictionary<string, Data>()) ?? new Data(-1);

            return (value.Type == typeof (Undefined))
                ? 0
                : (int)value.GetInteger();
        }
    }
}