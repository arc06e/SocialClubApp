using Microsoft.AspNetCore.Mvc;

namespace SocialClubApp.Controllers
{
    public class ClubController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
