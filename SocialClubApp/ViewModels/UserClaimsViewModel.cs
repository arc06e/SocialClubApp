namespace SocialClubApp.ViewModels
{
    public class UserClaimsViewModel
    {
        //initialized to avoid null error
        public UserClaimsViewModel()
        {
            Claims = new List<UserClaim>();
        }

        public string UserId { get; set; }
        public List<UserClaim> Claims { get; set; }
    }
}
