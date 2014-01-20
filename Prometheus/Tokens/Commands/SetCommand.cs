using System;
using Markdown.Documents;
using Prometheus.Tokens.Arguments;
using Prometheus.Tokens.Expressions;

namespace Prometheus.Tokens.Commands
{
    /// <summary>
    /// Assigns a value to a variable in memory.
    /// </summary>
    public class SetCommand : Command
    {
        /// <summary>
        /// The value reference.
        /// </summary>
        public BaseExpression Expression { get; private set; }

        /// <summary>
        /// The variable reference.
        /// </summary>
        public RefVariable Variable { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public SetCommand(Context pContext, DocumentCursor pCursor, RefVariable pVariable, BaseExpression pExpression)
            : base(pContext, pCursor)
        {
            Variable = pVariable;
            Expression = pExpression;
        }

        protected override bool Executing()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// For debugging
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Variable, Expression, base.ToString());
        }
    }
}