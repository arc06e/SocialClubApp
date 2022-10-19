using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialClubApp.DAL;
using SocialClubApp.Interfaces;
using SocialClubApp.Models;
//@inject UserManager<AppUser>();

namespace SocialClubApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;      

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;            
        }

        public async Task<AppUser> GetUserByIdAsync(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool Update(AppUser appUser)
        {
            _context.Update(appUser);
            return Save();
        }

        public bool Delete(AppUser appUser)
        {
            _context.Remove(appUser);
            return Save();
        }


        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
