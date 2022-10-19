using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialClubApp.Models;
using System.Security.Cryptography;
using System.Security.Principal;

namespace SocialClubApp.DAL
{                                       //inherits from DbContext
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {                               //carries configuration info                    //passes config info to base class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<UserClub> UserClubs { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //the keys of Identity tables are mapped in OnModelCreating method of IdentityDbContext
            //and if this method is not called, you will end up getting the error that you got.
            //This method is not called if you derive from IdentityDbContext and provide your own
            //definition of OnModelCreating as you did in your code. With this setup you have to
            //explicitly call the OnModelCreating method of IdentityDbContext
            //using base.OnModelCreating statement.


         

            builder.Entity<UserClub>()
            .HasKey(uc => new { uc.UserId, uc.ClubId });
            builder.Entity<UserClub>()
            .HasOne(uc => uc.User)
            .WithMany(u => u.UserClubs)
            .HasForeignKey(uc => uc.UserId);
            builder.Entity<UserClub>()
            .HasOne(uc => uc.Club)
            .WithMany(c => c.UserClubs)
            .HasForeignKey(uc => uc.ClubId);

        }
    }
}
