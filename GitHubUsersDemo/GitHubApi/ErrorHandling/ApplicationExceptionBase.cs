using System;

namespace GitHubApi.ErrorHandling
{
    public abstract class ApplicationExceptionBase : System.ApplicationException
    {
        protected ApplicationExceptionBase(string message, Exception innerException = null) : base(message, innerException)
        {
        }
    }
}