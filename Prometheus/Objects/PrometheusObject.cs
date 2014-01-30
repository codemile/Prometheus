using System;
using Prometheus.Compile;
using Prometheus.Exceptions;
using Prometheus.Grammar;
using Prometheus.Nodes;

namespace Prometheus.Objects
{
    /// <summary>
    /// Interface for all commands.
    /// </summary>
    public abstract class PrometheusObject
    {
        /// <summary>
        /// The container of executable objects.
        /// </summary>
        private readonly GrammarObject _objects;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pObjects">The grammar objects</param>
        protected PrometheusObject(GrammarObject pObjects)
        {
            _objects = pObjects;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pNode"></param>
        /// <returns></returns>
        protected PrometheusExpression getExpression(Node pNode)
        {
            PrometheusExpression expression = _objects.getObject(pNode) as PrometheusExpression;
            if (expression == null)
            {
                throw new CompilerException("Could not create expression object.", Cursor.None);
            }
            return expression;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pNode"></param>
        /// <returns></returns>
        protected PrometheusStatement getStatement(Node pNode)
        {
            PrometheusStatement statement = _objects.getObject(pNode) as PrometheusStatement;
            if (statement == null)
            {
                throw new CompilerException("Could not create statement object.", Cursor.None);
            }
            return statement;
        }
    }
}