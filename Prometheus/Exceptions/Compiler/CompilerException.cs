using System;
using System.Collections.Generic;
using Prometheus.Compile;

namespace Prometheus.Exceptions.Compiler
{
    /// <summary>
    /// The base exception for all compiler time errors.
    /// </summary>
    public class CompilerException : PrometheusException
    {
        /// <summary>
        /// Formats the message.
        /// </summary>
        private static string Format(string pMessage, Location pLocation)
        {
            List<string> message = new List<string>
                                   {
                                       string.Format("{0} {1}", pMessage, pLocation),
                                       "",
                                       pLocation.Line,
                                       "^".PadLeft(pLocation.Column)
                                   };

            return string.Join(Environment.NewLine, message);
        }

        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        protected CompilerException(string pMessage, Location pLocation, Exception pInnerException)
            : base(Format(pMessage, pLocation), pInnerException)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public CompilerException(string pMessage, Location pLocation)
            : base(Format(pMessage, pLocation))
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public CompilerException(string pMessage)
            : base(pMessage)
        {
        }
    }
}