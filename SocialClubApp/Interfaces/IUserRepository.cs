using SocialClubApp.Models;

namespace SocialClubApp.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser> GetUserByIdAsync(string id);

        public bool Update(AppUser appUser);
        public bool Delete(AppUser appUser);
        public bool Save();
    }
}
