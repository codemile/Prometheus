using System;
using Prometheus.Compile;
using Prometheus.Exceptions.Compiler;
using Prometheus.Exceptions.Parser;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Objects;

namespace Prometheus.Parser
{
    /// <summary>
    /// The run-time engine for Prometheus.
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// The compiled code
        /// </summary>
        private readonly TargetCode _code;

        /// <summary>
        /// No arguments
        /// </summary>
        private readonly object[] _noArgs = new object[0];

        /// <summary>
        /// No types
        /// </summary>
        private readonly Type[] _noTypes = new Type[0];

        /// <summary>
        /// The executable objects.
        /// </summary>
        private readonly GrammarObject _objects;

        /// <summary>
        /// Executes an object as a statement
        /// </summary>
        /// <param name="pNode">The node being executed</param>
        private Data Execute(Node pNode)
        {
            PrometheusObject proObj = _objects.getObject(pNode);
            if (proObj == null)
            {
                throw new UnsupportedSymbolException("Symbol is not implemented", pNode);
            }

            int count = pNode.Children.Count;
            Data[] values = new Data[count];
            for (int i = 0; i < count; i++)
            {
                values[i] = Execute(pNode.Children[i]);
            }

            return proObj.Execute(pNode, values);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pCode">The compiled code to parse.</param>
        public Parser(TargetCode pCode)
        {
            _code = pCode;
            _objects = new GrammarObject();
        }

        /// <summary>
        /// Runs the code
        /// </summary>
        public void Run()
        {
            Execute(_code.Root);
        }
    }
}