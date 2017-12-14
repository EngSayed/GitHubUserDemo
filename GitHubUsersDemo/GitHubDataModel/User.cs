using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GitHubDataModel
{
    public class User
    {
        public string Login { get; set; }
        public int Id { get; set; }
        public string AvatarUrl { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Location")]
        public string Location { get; set; }
        public IEnumerable<UserRepo> Repositories { get; set; }

        public override bool Equals(object obj)
        {
            var y = obj as User;
            return y   != null      && 
                   Name == y.Name   &&
                   Id   == y.Id     &&
                   Location == y.Location;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}