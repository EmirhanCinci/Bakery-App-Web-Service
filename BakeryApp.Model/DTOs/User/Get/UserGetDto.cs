using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.DTOs.User.Get
{
    public class UserGetDto : Dto<int>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CityName { get; set; }
        public string GenderName { get; set; }
    }
}
