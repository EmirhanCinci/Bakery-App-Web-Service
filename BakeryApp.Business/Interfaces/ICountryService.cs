using BakeryApp.Model.DTOs.Country.Get;
using BakeryApp.Model.DTOs.Country.Post;
using BakeryApp.Model.DTOs.Country.Put;
using BakeryApp.Model.Entities;
using Infrastructure.Business.Interfaces;
using Infrastructure.Utilities.ApiResponses;

namespace BakeryApp.Business.Interfaces
{
    public interface ICountryService : IBaseService<Country, int>
    {
        Task<CustomResponse<List<CountryGetDto>>> GetCountriesAsync();
        Task<CustomResponse<CountryGetDto>> GetCountryByIdAsync(int id);
        Task<CustomResponse<CountryGetDto>> AddCountryAsync(CountryPostDto countryPostDto);
        Task<CustomResponse<NoData>> UpdateCountryAsync(CountryPutDto countryPutDto);
        Task<CustomResponse<NoData>> DeleteCountryAsync(int id);
    }
}
