using Microsoft.EntityFrameworkCore;
using SocialClubApp.Models;

namespace SocialClubApp.Interfaces
{
    public interface IClubRepository
    {
        Task<IEnumerable<Club>> GetAll();
        Task<Club> GetByIdAsync(int id);
        Task<Club> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Club>> GetClubByCity(string city);
        //CRUD
        bool Add(Club club);
        bool Update(Club club);
        bool Delete(Club club);
        bool Save();

        //tinkering with joining club
        public bool JoinClub(UserClub link);
        public bool QuitClub(UserClub link);
        public Task<bool> IsClubJoinedAsync(int clubId, string userId);

        public Task<List<AppUser>> GetClubMembers(int clubId);

    }
}
