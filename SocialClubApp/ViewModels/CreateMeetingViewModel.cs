using SocialClubApp.DAL.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialClubApp.ViewModels
{
    public class CreateMeetingViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public MeetingCategory? MeetingCategory { get; set; }
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }
    }
}
