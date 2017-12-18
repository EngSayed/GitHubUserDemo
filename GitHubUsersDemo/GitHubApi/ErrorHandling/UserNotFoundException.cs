using System;

namespace GitHubApi.ErrorHandling
{
    public class UserNotFoundException : ApplicationExceptionBase
    {
        public UserNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}