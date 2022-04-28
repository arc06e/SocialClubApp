using Microsoft.EntityFrameworkCore;
using SocialClubApp.DAL;
using SocialClubApp.Interfaces;
using SocialClubApp.Models;

namespace SocialClubApp.Repositories
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDbContext _context;

        public ClubRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Club>> GetAll()
        {
            return await _context.Clubs.ToListAsync();
        }

        public async Task<Club> GetByIdAsync(int id)
        {                               
            return await _context.Clubs.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Club> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Clubs.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Club>> GetClubByCity(string city)
        {
            return await _context.Clubs.Where(c => c.City.Contains(city)).ToListAsync();
        }

        public bool Add(Club club)
        {
            _context.Add(club); //EF generates relevant SQL commands
            return Save(); //EF sends SQL commands to Db - done through tracking
        }

        public bool Delete(Club club)
        {
            _context.Remove(club);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Club club)
        {
            _context.Update(club);
            return Save();
        }
    }
}
