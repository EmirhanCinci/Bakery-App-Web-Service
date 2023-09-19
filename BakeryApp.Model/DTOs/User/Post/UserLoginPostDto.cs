using Infrastructure.Model.Interfaces;

namespace BakeryApp.Model.DTOs.User.Post
{
    public class UserLoginPostDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
