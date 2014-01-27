using System;
using Prometheus.Documents;

namespace Prometheus.Tokens.Arguments
{
    /// <summary>
    /// Holds a reference to an in memory variable.
    /// </summary>
    public class RefVariable : Ref
    {
        /// <summary>
        /// The name of the variable.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The scope of the variable.
        /// </summary>
        private string _scope { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public RefVariable(Context pContext, Cursor pCursor, string pName)
            : base(pContext, pCursor)
        {
            _scope = "GLOBAL";
            Name = pName;
        }

        /// <summary>
        /// Debugging
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0}:{1}", _scope, Name);
        }

        /// <summary>
        /// </summary>
        public override string getString()
        {
            throw new NotImplementedException();
        }
    }
}