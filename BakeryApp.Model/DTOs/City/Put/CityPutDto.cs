using Infrastructure.Model.Interfaces;

namespace BakeryApp.Model.DTOs.City.Put
{
    public class CityPutDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
