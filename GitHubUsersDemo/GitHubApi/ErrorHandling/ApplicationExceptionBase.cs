using System;

namespace GitHubApi.ErrorHandling
{
    public abstract class ApplicationExceptionBase : Exception
    {
        public string DisplayMessage { get; set; }

        protected ApplicationExceptionBase(string message)
        {
            DisplayMessage = message;
        }
    }
}