using System;
using Logging;
using Prometheus.Compile;
using Prometheus.Exceptions;

namespace Prometheus.Tokens.Blocks
{
    /// <summary>
    /// Represents the root node that is the result of compiling source code.
    /// </summary>
    public class Program : Token
    {
        /// <summary>
        /// For logging exceptions
        /// </summary>
        private readonly Logger _logger = Logger.Create(typeof (Program));

        /// <summary>
        /// The main block of code.
        /// </summary>
        public Block Main { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Program(Context pContext, Cursor pCursor, Block pBlock)
            : base(pContext, pCursor)
        {
            Main = pBlock;
        }

        /// <summary>
        /// Runs the program.
        /// In most cases this will return False when there is an error, but
        /// if there is an exit statement. That will also generate a false
        /// return.
        /// </summary>
        /// <returns>False if the program exited before it finished.</returns>
        public bool Run()
        {
            try
            {
                return Main.Execute();
            }
            catch (CompilerException e)
            {
                Context.Status = Context.StatusType.ERROR;
                Context.LastError = e;
                _logger.Exception(e);
            }
            catch (Exception e)
            {
                Context.Status = Context.StatusType.ERROR;
                Context.LastError = e;
                _logger.Error("Non-parser exception caught", Cursor);
                _logger.Exception(e);
            }

            return false;
        }
    }
}