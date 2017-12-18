using System;

namespace GitHubApi.ErrorHandling
{
    public class ApplicationGeneralException : ApplicationExceptionBase
    {
        public ApplicationGeneralException(string message, Exception innerException = null) : base(message, innerException)
        {
        }
    }
}