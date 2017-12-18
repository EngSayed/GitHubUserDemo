using System;

namespace GitHubApi.ErrorHandling
{
    public class ExceptionFactory
    {
        public static ApplicationExceptionBase GetException(Exception exception)
        {
            if (exception.Message.ToLower().Contains("not found"))
            {
                return new UserNotFoundException("User cannot be found", exception);
            }

            if (exception.Message.ToLower().Contains("string cannot be empty"))
            {
                return new ApplicationGeneralException("Login name cannot be empty", exception);
            }

            return new ApplicationGeneralException(exception.Message, exception);
        }
    }
}