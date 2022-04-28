using System.Security.Claims;

namespace SocialClubApp
{
    public static class ClaimsPrincipalExtensions
    {                                 // this - referring to claimsprinciple isntance - cf ClubController
        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
