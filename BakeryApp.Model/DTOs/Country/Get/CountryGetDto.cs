using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.DTOs.Country.Get
{
    public class CountryGetDto : Dto<int>
    {
        public string Name { get; set; }
    }
}
