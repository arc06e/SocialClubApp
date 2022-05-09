using Microsoft.EntityFrameworkCore;
using SocialClubApp.DAL;
using SocialClubApp.Interfaces;
using SocialClubApp.Models;

namespace SocialClubApp.Repositories
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly ApplicationDbContext _context;

        public MeetingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Meeting>> GetAll()
        {
            return await _context.Meetings.ToListAsync();
        }

        public async Task<IEnumerable<Meeting>> GetAllMeetingsByCity(string city)
        {
            return await _context.Meetings.Where(c => c.City.Contains(city)).ToListAsync();
        }

        public async Task<Meeting> GetByIdAsync(int id)
        {
            return await _context.Meetings.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Meeting> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Meetings.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public bool Add(Meeting meeting)
        {
            _context.Add(meeting);
            return Save();
        }

        public bool Delete(Meeting meeting)
        {
            _context.Remove(meeting);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Meeting meeting)
        {
            _context.Update(meeting);
            return Save();
        }
    }
}
