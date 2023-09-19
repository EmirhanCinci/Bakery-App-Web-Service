using Infrastructure.Model.Interfaces;

namespace BakeryApp.Model.DTOs.User.Post
{
    public class UserPostDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CityId { get; set; }
        public int GenderId { get; set; }
        public string Password { get; set; }
    }
}
