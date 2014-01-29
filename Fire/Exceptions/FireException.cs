using System;

namespace Fire.Exceptions
{
    public abstract class FireException : Exception
    {
        protected FireException(string pMessage, object[] pArgs)
            : base(string.Format(pMessage, pArgs))
        {
        }
    }
}