using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialClubApp.Interfaces;
using SocialClubApp.Models;

using SocialClubApp.ViewModels;
using System.Diagnostics.Metrics;

namespace SocialClubApp.Controllers
{
    
    public class ClubController : Controller
    {
        private readonly IClubRepository _clubRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public ClubController(IClubRepository clubRepository, IPhotoService photoService,
            IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _clubRepository = clubRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Club> clubs = await _clubRepository.GetAll();
            return View(clubs);
        }

        [Authorize]
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(int id) 
        {
            Club club = await _clubRepository.GetByIdAsync(id);
            AppUser user = await _userManager.GetUserAsync(User);
            var isClubJoined = await _clubRepository.IsClubJoinedAsync(club.Id, user.Id);
            var clubMembers = await _clubRepository.GetClubMembers(id);

            var clubMemberListVM = new List<ClubMemberViewModel>();

            
            foreach (var clubMember in clubMembers) 
            {
                var userClaims = await _userManager.GetClaimsAsync(clubMember);
                var memberClaims = userClaims.Select(c => c.Value).ToList();
                var memberList = new List<string>();

                var clubMemberVM = new ClubMemberViewModel();
                {
                    clubMemberVM.Id = clubMember.Id;
                    clubMemberVM.UserName = clubMember.UserName;
                    clubMemberVM.Email = clubMember.Email;
                    clubMemberVM.City = clubMember.City;
                    clubMemberVM.State = clubMember.State;                    
                    clubMemberVM.ProfileImageUrl = clubMember.ProfileImageUrl;
                    clubMemberVM.Joined = clubMember.Joined;
                    clubMemberVM.Claims = memberList;

                    memberList.AddRange(memberClaims);

                    // will not copy your object,
                    // because Objects are passed by reference
                    // this is why we initialize the object INSIDE the foreach loop
                    clubMemberListVM.Add(clubMemberVM);
                }
            }
                        
            var clubVM = new ClubViewModel
            {
                Id = club.Id,
                Image = club.Image,
                Title = club.Title,
                City = club.City,
                State = club.State,
                ClubCategory = club.ClubCategory,
                Description = club.Description,
                AppUserId = club.AppUserId,
                IsJoined = isClubJoined,
                //ClubMembers = clubMembers,
                Members = clubMemberListVM
               
            };

            return View(clubVM);
        }

        [Authorize]
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
                return View(clubVM);
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

        [Authorize(Policy = "ModPolicy")]
        [HttpGet]        
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> JoinClub(ClubViewModel clubViewModel)
        {
            var user = await _userManager.GetUserAsync(User);
            var club = await _clubRepository.GetByIdAsync(clubViewModel.Id);

            if (user == null || club == null) 
            {
                return NotFound();
            }            

            var link = new UserClub { Club = club, ClubId = club.Id, User = user, UserId = user.Id };

            if (clubViewModel.IsJoined)
            {
                _clubRepository.QuitClub(link);
            }
            else 
            {
                _clubRepository.JoinClub(link);
            }

            return RedirectToAction("Details", new { id = club.Id});
        }
    }
}
