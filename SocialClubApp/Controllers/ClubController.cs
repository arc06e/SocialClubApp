using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialClubApp.Interfaces;
using SocialClubApp.Models;

using SocialClubApp.ViewModels;

namespace SocialClubApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository _clubRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClubController(IClubRepository clubRepository, IPhotoService photoService,
            IHttpContextAccessor httpContextAccessor)
        {
            _clubRepository = clubRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Club> clubs = await _clubRepository.GetAll();
            return View(clubs);
        }

        [HttpGet]
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
                var result = await _photoService.AddPhotoAsync(clubVM.Image);

                var club = new Club()
                {
                    Title = clubVM.Title,
                    Description = clubVM.Description,
                    AppUserId = clubVM.AppUserId,
                    City = clubVM.City,
                    State = clubVM.State,
                    ClubCategory = clubVM.ClubCategory,
                    Image = result.Url.ToString()
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

        [HttpGet]
        public async Task<IActionResult> Details(int id) 
        {
            Club club = await _clubRepository.GetByIdAsync(id);
            return View(club);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) 
        {
            var club = await _clubRepository.GetByIdAsync(id);
            
            if (club == null) 
            {
                return View("Error");
            }

            var editVM = new EditClubViewModel
            {
                Title = club.Title,
                City = club.City,
                State = club.State,
                ClubCategory = club.ClubCategory,   
                Description= club.Description,
                URL = club.Image
            };
            return View(editVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditClubViewModel clubVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Failed to edit club");
                return View("Error", clubVM);
            }

            var userClub = await _clubRepository.GetByIdAsyncNoTracking(id);

            if (userClub != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userClub.Image);
                }
                catch
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(clubVM);
                }

                var photoResult = await _photoService.AddPhotoAsync(clubVM.Image);

                var club = new Club()
                {
                    Id = clubVM.Id,
                    Title = clubVM.Title,
                    City = clubVM.City,
                    State = clubVM.State,
                    Image = photoResult.Url.ToString(),
                    ClubCategory = clubVM.ClubCategory,
                    Description = clubVM.Description
                };
                _clubRepository.Update(club);
                return RedirectToAction("Index");
            }
            else
            {
                return View(clubVM);
            }
            
        }

        [HttpGet]
        [Authorize(Policy = "DeleteClubPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            var clubDetails = await _clubRepository.GetByIdAsync(id);
            if (clubDetails == null)
            {
                return View("Error");
            }    
                
            return View(clubDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var clubDetails = await _clubRepository.GetByIdAsync(id);
            if (clubDetails == null) 
            {
                return View("Error");
            } 

            _clubRepository.Delete(clubDetails);
            return RedirectToAction("Index");
        }
    }
}
