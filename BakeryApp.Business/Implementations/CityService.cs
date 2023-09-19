using AutoMapper;
using BakeryApp.Business.Constants.City;
using BakeryApp.Business.Interfaces;
using BakeryApp.Business.Validations.City;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.DTOs.City.Get;
using BakeryApp.Model.DTOs.City.Post;
using BakeryApp.Model.DTOs.City.Put;
using BakeryApp.Model.Entities;
using Infrastructure.Aspects.Caching;
using Infrastructure.Aspects.IdParameter;
using Infrastructure.Aspects.Performance;
using Infrastructure.Aspects.Validation;
using Infrastructure.CrossCuttingConcerns.Exceptions;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;

namespace BakeryApp.Business.Implementations
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        private async Task CheckIfCityNameExists(string cityName, int countryId)
        {
            var cityToCheck = await _cityRepository.AnyAsync(p => p.Name.ToLower() == cityName.ToLower() && p.CountryId == countryId);
            if (cityToCheck)
            {
                throw new BusinessRuleException(CityErrorMessages.NameExists);
            }
        }

        [ValidationAspect(typeof(CityPostDtoValidator))]
        [CacheRemoveAspect("ICityService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<CityGetDto>> AddCityAsync(CityPostDto cityPostDto)
        {
            await CheckIfCityNameExists(cityPostDto.Name, cityPostDto.CountryId);
            var city = _mapper.Map<City>(cityPostDto);
            var inserted = await _cityRepository.AddAsync(city);
            var insertedCity = await _cityRepository.GetByIdAsync(inserted.Id, false, includeList: "Country");
            var dto = _mapper.Map<CityGetDto>(insertedCity);
            return CustomResponse<CityGetDto>.Success(StatusCodes.Status201Created, dto);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public Task<bool> AnyAsync(int id)
        {
            return _cityRepository.AnyIdAsync(id, false);
        }

        [IdCheckAspect]
        [CacheRemoveAspect("ICityService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<NoData>> DeleteCityAsync(int id)
        {
            var city = await _cityRepository.GetByIdAsync(id);
            await _cityRepository.DeleteAsync(city);
            return CustomResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        [CacheAddAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<List<CityGetDto>>> GetAllCitiesAsync()
        {
            var cities = await _cityRepository.GetListAsync();
            if (cities != null && cities.Count > 0)
            {
                var dtoList = _mapper.Map<List<CityGetDto>>(cities);
                return CustomResponse<List<CityGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException(CityErrorMessages.NotFoundCities);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<CityGetDto>> GetCityByIdAsync(int id)
        {
            var city = await _cityRepository.GetByIdAsync(id, false, includeList: "Country");
            var dto = _mapper.Map<CityGetDto>(city);
            return CustomResponse<CityGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        [ValidationAspect(typeof(CityPutDtoValidator))]
        [CacheRemoveAspect("ICityService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<NoData>> UpdateCityAsync(CityPutDto cityPutDto)
        {
            var city = await _cityRepository.GetByIdAsync(cityPutDto.Id, false);
            if (city != null)
            {
                var updatedCity = _mapper.Map<City>(cityPutDto);
                updatedCity.CreatedDate = city.CreatedDate;
                await _cityRepository.UpdateAsync(updatedCity);
                return CustomResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException(CityErrorMessages.NotFoundById);
        }
    }
}
