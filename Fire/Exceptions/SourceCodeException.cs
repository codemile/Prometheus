namespace Fire.Exceptions
{
    public class SourceCodeException : FireException
    {
        public SourceCodeException(string pMessage, params object[] pArgs) 
            : base(pMessage, pArgs)
        {
        }
    }
}