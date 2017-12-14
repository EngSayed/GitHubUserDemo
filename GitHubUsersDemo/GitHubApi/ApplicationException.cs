using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi
{
    public abstract class ApplicationExceptionBase : Exception
    {
        public string DisplayMessage { get; set; }

        protected ApplicationExceptionBase(string message)
        {
            DisplayMessage = message;
        }
    }

    public class ApplicationException : ApplicationExceptionBase
    {
        public ApplicationException(string message) : base(message)
        {
        }
    }

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

/*

String cannot be empty
Parameter name: login

*/
/*
{"message":"Not Found","documentation_url":"https://developer.github.com/v3/users/#get-a-single-user"}
    */
