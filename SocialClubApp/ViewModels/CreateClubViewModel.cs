using SocialClubApp.DAL.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialClubApp.ViewModels
{
    public class CreateClubViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //    public string Image { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public ClubCategory? ClubCategory { get; set; }
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
    }
}
