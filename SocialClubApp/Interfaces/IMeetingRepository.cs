using SocialClubApp.Models;

namespace SocialClubApp.Interfaces
{
    public interface IMeetingRepository
    {
        Task<IEnumerable<Meeting>> GetAll();
        Task<Meeting> GetByIdAsync(int id);
        Task<Meeting> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Meeting>> GetAllMeetingsByCity(string city);
        //CRUD
        bool Add(Meeting meeting);
        bool Update(Meeting meeting);
        bool Delete(Meeting meeting);
        bool Save();
    }
}
