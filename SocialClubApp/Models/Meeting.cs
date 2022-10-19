using SocialClubApp.DAL.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialClubApp.Models
{
    public class Meeting
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/8/89/Portrait_Placeholder.png";
        public string City { get; set; }
        public string State { get; set; }
        public MeetingCategory? MeetingCategory { get; set; }
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
