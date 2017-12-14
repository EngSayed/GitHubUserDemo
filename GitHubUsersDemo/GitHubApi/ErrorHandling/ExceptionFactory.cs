using System;

namespace GitHubApi.ErrorHandling
{
    public class ExceptionFactory
    {
        public static ApplicationExceptionBase GetException(Exception exception)
        {
            if (exception.Message.ToLower().Contains("not found"))
            {
                return new UserNotFoundException("User cannot be found");
            }

            if (exception.Message.ToLower().Contains("string cannot be empty"))
            {
                return new ApplicationException("Login name cannot be empty");
            }

            return new ApplicationException(exception.Message);
        }
    }
}