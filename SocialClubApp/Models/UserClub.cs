namespace SocialClubApp.Models
{
    public class UserClub
    {
        public string UserId { get; set; }
        public int ClubId { get; set; }

        public AppUser User { get; set; }
        public Club Club { get; set; }
    }
}
