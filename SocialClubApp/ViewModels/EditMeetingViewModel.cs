using SocialClubApp.DAL.Enum;

namespace SocialClubApp.ViewModels
{
    public class EditMeetingViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string? URL { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public MeetingCategory? MeetingCategory { get; set; }
       
    }
}
