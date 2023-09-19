using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.DTOs.City.Get
{
    public class CityGetDto : Dto<int>
    {
        public string Name { get; set; }
        public string CountryName { get; set; }
    }
}
