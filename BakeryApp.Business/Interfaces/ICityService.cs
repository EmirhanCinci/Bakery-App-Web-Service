using BakeryApp.Model.DTOs.City.Get;
using BakeryApp.Model.DTOs.City.Post;
using BakeryApp.Model.DTOs.City.Put;
using BakeryApp.Model.Entities;
using Infrastructure.Business.Interfaces;
using Infrastructure.Utilities.ApiResponses;

namespace BakeryApp.Business.Interfaces
{
    public interface ICityService : IBaseService<City, int>
    {
        Task<CustomResponse<List<CityGetDto>>> GetAllCitiesAsync();
        Task<CustomResponse<CityGetDto>> GetCityByIdAsync(int id);
        Task<CustomResponse<CityGetDto>> AddCityAsync(CityPostDto cityPostDto);
        Task<CustomResponse<NoData>> UpdateCityAsync(CityPutDto cityPutDto);
        Task<CustomResponse<NoData>> DeleteCityAsync(int id);
    }
}
