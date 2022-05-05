using System.ComponentModel.DataAnnotations;

namespace SocialClubApp.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
