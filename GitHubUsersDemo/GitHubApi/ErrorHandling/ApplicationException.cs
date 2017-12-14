namespace GitHubApi.ErrorHandling
{
    public class ApplicationException : ApplicationExceptionBase
    {
        public ApplicationException(string message) : base(message)
        {
        }
    }
}