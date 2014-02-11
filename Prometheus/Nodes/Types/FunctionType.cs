using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Holds a reference to an un-compiled function.
    /// </summary>
    public class FunctionType : DataType
    {
        public readonly Node Func;

        public FunctionType(Node pFunc)
        {
            Func = pFunc;
        }
    }
}
