using System.Collections.Generic;
using Prometheus.Compile;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
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
                Dictionary<string, DataType> globals = new Dictionary<string, DataType>();

                // create root object (the default "this" reference)
                DataType _this = executor.Cursor.Heap.Add(new Instance(null));
                globals.Add("this", _this);

                using (executor.Cursor.Stack = new StackSpace(executor.Cursor, globals))
                {
                    DataType value = executor.Execute(pCode.Root, new Dictionary<string, DataType>()) ?? new NumericType(-1);

                    NumericType num = value as NumericType;
                    return (num != null) ? (int)num.getLong() : 0;
                }
            }
        }
    }
}