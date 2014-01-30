using System;
using Logging;
using Prometheus.Compile;
using Prometheus.Exceptions;
using Prometheus.Exceptions.Compiler;

namespace Prometheus.Tokens.Statements
{
    /// <summary>
    /// A base class that represents all executable statements.
    /// </summary>
    public abstract class Statement : Token
    {
        /// <summary>
        /// For logging exceptions
        /// </summary>
        private readonly Logger _logger = Logger.Create(typeof (Statement));

        /// <summary>
        /// Executes the virtual Always method.
        /// </summary>
        private void AlwaysSafe()
        {
            try
            {
                Always();
            }
            catch (CompilerException e)
            {
                _logger.Error("Always caused exception.");
                _logger.Exception(e);
            }
            catch (Exception e)
            {
                _logger.Error("Always caused exception.");
                _logger.Error("Non-parser exception caught", Cursor);
                _logger.Exception(e);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        protected Statement(Context pContext, Cursor pCursor)
            : base(pContext, pCursor)
        {
        }

        /// <summary>
        /// A virtual method that is always executed. Even if
        /// the statement throws an exception.
        /// </summary>
        protected virtual void Always()
        {
        }

        /// <summary>
        /// Derived classes implement this method to perform the
        /// work of the statement.
        /// </summary>
        /// <returns>True to continue, False to exit program.</returns>
        protected abstract bool Executing();

        /// <summary>
        /// Executes this statement.
        /// </summary>
        public bool Execute()
        {
            try
            {
                return Executing();
            }
            finally
            {
                AlwaysSafe();
            }
        }
    }
}