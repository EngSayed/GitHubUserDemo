using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GitHubUsersWeb.Models
{
    public class UserViewModel
    {
        public string Login { get; set; }
        public int Id { get; set; }
        [Display(Name = "Photo")]
        public string AvatarUrl { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Location")]
        public string Location { get; set; }

        public string ErrorMessage { get; set; }
        public IEnumerable<UserReporViewModel> Repositories { get; set; }

        public override bool Equals(object obj)
        {
            var y = obj as UserViewModel;
            return y       != null  && Name == y.Name &&
                   Id       == y.Id &&
                   Location == y.Location;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}