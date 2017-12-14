using System.ComponentModel.DataAnnotations;

namespace GitHubUsersWeb.Models
{
    public class UserReporViewModel
    {
        public string Name { get; set; }
        [Display(Name = "SVN Url")]
        public string SvnUrl { get; set; }
        public long Id { get; set; }
        public UserViewModel Owner { get; set; }
        [Display(Name = "Full name")]
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        [Display(Name = "Stargazers Count")]
        public int StargazersCount { get; set; }
    }
}