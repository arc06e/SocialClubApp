using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialClubApp.Models
{
    public class AppUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
        //    public string? ProfileImageUrl { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public ICollection<Club> Clubs { get; set; }
        public ICollection<Meeting> Events { get; set; }
    }

    //public class AppUser : IdentityUser
    //{
    //    public int? Pace { get; set; }
    //    public int? Mileage { get; set; }

    //    public string? ProfileImageUrl { get; set; }

    //    public string? City { get; set; }
    //    public string? State { get; set; }
    //    [ForeignKey("Address")]
    //    public int? AddressId { get; set; }
    //    public Address? Address { get; set; }
    //    public ICollection<Club> Clubs { get; set; }
    //    public ICollection<Race> Races { get; set; }
    //}
}
