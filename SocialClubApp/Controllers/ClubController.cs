using Microsoft.AspNetCore.Mvc;
using SocialClubApp.Interfaces;
using SocialClubApp.Models;

using SocialClubApp.ViewModels;

namespace SocialClubApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository _clubRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClubController(IClubRepository clubRepository, IHttpContextAccessor httpContextAccessor)
        {
            _clubRepository = clubRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task<IActionResult> Index()
        {
            IEnumerable<Club> clubs = await _clubRepository.GetAll();
            return View(clubs);
        }

        public IActionResult Create() 
        {
            var currentUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var createVM = new CreateClubViewModel { AppUserId = currentUserId };

            return View(createVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClubViewModel clubVM) 
        {
            if (ModelState.IsValid)
            {
                var club = new Club()
                {
                    Title = clubVM.Title,
                    Description = clubVM.Description,
                    AppUserId = clubVM.AppUserId,
                    City = clubVM.City,
                    State = clubVM.State,
                    ClubCategory = clubVM.ClubCategory,
                };
                _clubRepository.Add(club);
                return RedirectToAction("Index");
            }
            else 
            {
                ModelState.AddModelError(string.Empty, "Error with submission");
            }

            return View(clubVM);
        }
    }
}
