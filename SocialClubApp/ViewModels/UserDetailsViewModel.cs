using System.ComponentModel.DataAnnotations;

namespace SocialClubApp.ViewModels
{
    public class UserDetailsViewModel
    {

        //To avoid NullReferenceExceptions at runtime,
        //initialise Claims and Roles with a new list in the constructor.
        public UserDetailsViewModel()
        {
            Claims = new List<string>();
        }

        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public List<string> Claims { get; set; }

    }
}
