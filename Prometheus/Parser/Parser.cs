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
                Dictionary<string, iDataType> globals = new Dictionary<string, iDataType>();

                // create root object (the default "this" reference)
                iDataType _this = executor.Cursor.Heap.Add(new Instance(null));
                globals.Add("this", _this);

                using (executor.Cursor.Stack = new StackSpace(executor.Cursor, globals))
                {
                    iDataType value = executor.Execute(pCode.Root, new Dictionary<string, iDataType>()) ??
                                     new IntegerType(-1);

                    return (int)((value is UndefinedType)
                        ? 0
                        : ((IntegerType)value).Value);
                }
            }
        }
    }
}