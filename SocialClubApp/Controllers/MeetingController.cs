using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialClubApp.Interfaces;
using SocialClubApp.Models;
using SocialClubApp.ViewModels;

namespace SocialClubApp.Controllers
{
    [Authorize]
    public class MeetingController : Controller
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MeetingController(IMeetingRepository meetingRepository, IPhotoService photoService,
            IHttpContextAccessor httpContextAccessor)
        {
            _meetingRepository = meetingRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Meeting> meetings = await _meetingRepository.GetAll();
            return View(meetings);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var currentUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var createVM = new CreateMeetingViewModel { AppUserId = currentUserId };

            return View(createVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMeetingViewModel meetingVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(meetingVM.Image);

                var meeting = new Meeting()
                {
                    Title = meetingVM.Title,
                    Description = meetingVM.Description,
                    AppUserId = meetingVM.AppUserId,
                    City = meetingVM.City,
                    State = meetingVM.State,
                    MeetingCategory = meetingVM.MeetingCategory,
                    Image = result.Url.ToString()
                };
                _meetingRepository.Add(meeting);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error with submission");
            }

            return View(meetingVM);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Meeting meeting = await _meetingRepository.GetByIdAsync(id);
            return View(meeting);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var club = await _meetingRepository.GetByIdAsync(id);

            if (club == null)
            {
                return View("Error");
            }

            var editVM = new EditMeetingViewModel
            {
                Title = club.Title,
                City = club.City,
                State = club.State,
                MeetingCategory = club.MeetingCategory,
                Description = club.Description,
                URL = club.Image
            };
            return View(editVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditMeetingViewModel meetingVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Failed to edit event");
                return View(meetingVM);
            }

            var userClub = await _meetingRepository.GetByIdAsyncNoTracking(id);

            if (userClub != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userClub.Image);
                }
                catch
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(meetingVM);
                }

                var photoResult = await _photoService.AddPhotoAsync(meetingVM.Image);

                var meeting = new Meeting()
                {
                    Id = meetingVM.Id,
                    Title = meetingVM.Title,
                    City = meetingVM.City,
                    State = meetingVM.State,
                    Image = photoResult.Url.ToString(),
                    MeetingCategory = meetingVM.MeetingCategory,
                    Description = meetingVM.Description
                };
                _meetingRepository.Update(meeting);
                return RedirectToAction("Index");
            }
            else
            {
                return View(meetingVM);
            }

        }

        [HttpGet]
        [Authorize(Policy = "ModPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            var meetingDetails = await _meetingRepository.GetByIdAsync(id);
            if (meetingDetails == null)
            {
                return View("Error");
            }

            return View(meetingDetails);
        }

        [HttpPost, ActionName("Delete")]        
        public async Task<IActionResult> DeleteMeeting(int id)
        {
            var meetingDetails = await _meetingRepository.GetByIdAsync(id);
            if (meetingDetails == null)
            {
                return View("Error");
            }

            _meetingRepository.Delete(meetingDetails);
            return RedirectToAction("Index");
        }
    }
}
