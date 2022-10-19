using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialClubApp.Models
{
    public class AppUser : IdentityUser
    {

        [Column(TypeName = "nvarchar(100)")]
        public string? FirstName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? LastName { get; set; }
        public string? ProfileImageUrl { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/8/89/Portrait_Placeholder.png";
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true,
        //  DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? Joined { get; set; } = DateTime.Now;
        public ICollection<Club> Clubs { get; set; }
        public ICollection<Meeting> Events { get; set; }
        //public ICollection<Club> JoinedClubs { get; set; }
        public ICollection<UserClub> UserClubs { get; set; }
    }
}
