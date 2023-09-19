using Infrastructure.Model.Interfaces;

namespace BakeryApp.Model.DTOs.City.Post
{
    public class CityPostDto : IDto
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
