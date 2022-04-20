using System.ComponentModel.DataAnnotations;

namespace SocialClubApp.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //explain this
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
