using Infrastructure.Model.Interfaces;

namespace BakeryApp.Model.DTOs.Country.Put
{
    public class CountryPutDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
