using System.Collections.Generic;
using Prometheus.Compile;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Objects;
using Prometheus.Parser.Executors;
using Prometheus.Storage;

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
            using (Executor executor = new Executor())
            {
                // create the global variables
                Dictionary<string, Data> globals = new Dictionary<string, Data>();

                // create root object (the default "this" reference)
                Data _this = executor.Cursor.Heap.Add(new Instance());
                globals.Add("this", _this);

                using (executor.Cursor.Stack = new StackSpace(executor.Cursor, globals))
                {
                    Data value = executor.Execute(pCode.Root, new Dictionary<string, Data>()) ?? new Data(-1);

                    return (value.Type == typeof(Undefined))
                        ? 0
                        : (int)value.getInteger();
                }
            }
        }
    }
}