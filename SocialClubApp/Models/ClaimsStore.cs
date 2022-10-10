using System.Security.Claims;

namespace SocialClubApp.Models
{
    public static class ClaimsStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {            //claim type   //claim value 
            //new Claim("Create Role", "Create Role"),
            //new Claim("Edit Role", "Edit Role"),
            //new Claim("Delete Role", "Delete Role"),
            //new Claim("Delete Club", "Delete Club"),
            //new Claim("Delete Meeting", "Delete Meeting")
            new Claim("Admin", "Admin"),
            new Claim("Mod", "Mod")
        };
    }
}
