namespace GitHubApi
{
    public class UserNotFoundException : ApplicationExceptionBase
    {
        public UserNotFoundException(string message) : base(message)
        {
        }
    }
}