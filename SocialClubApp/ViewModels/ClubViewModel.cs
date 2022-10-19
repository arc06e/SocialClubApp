using SocialClubApp.DAL.Enum;
using SocialClubApp.Models;
using System.Net;

namespace SocialClubApp.ViewModels
{
    public class ClubViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        //public Address? Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public ClubCategory? ClubCategory { get; set; }

        public string? AppUserId { get; set; }
        public DateTime? ClubCreated { get; set; }
        public List<AppUser> ClubMembers { get; set; }
        public bool IsJoined { get; set; }

        public List<ClubMemberViewModel> Members { get; set; }
        //public List<CommentViewModel> Comments { get; set; }
    }
}
