using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialClubApp.Models;

namespace SocialClubApp.DAL
{                                       //inherits from DbContext
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {                               //carries configuration info                    //passes config info to base class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<Meeting> Meetings { get; set; }

    }
}
