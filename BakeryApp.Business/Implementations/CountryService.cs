using AutoMapper;
using BakeryApp.Business.Constants.Country;
using BakeryApp.Business.Interfaces;
using BakeryApp.Business.Validations.Country;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.DTOs.Country.Get;
using BakeryApp.Model.DTOs.Country.Post;
using BakeryApp.Model.DTOs.Country.Put;
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
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        private async Task CheckIfCountryNameExists(string countryName)
        {
            var countryToCheck = await _countryRepository.AnyAsync(p => p.Name.ToLower() == countryName.ToLower());
            if (countryToCheck)
            {
                throw new BusinessRuleException(CountryErrorMessages.NameExists);
            }
        }

        [ValidationAspect(typeof(CountryPostDtoValidator))]
        [CacheRemoveAspect("ICountryService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<CountryGetDto>> AddCountryAsync(CountryPostDto countryPostDto)
        {
            await CheckIfCountryNameExists(countryPostDto.Name);
            var country = _mapper.Map<Country>(countryPostDto);
            var inserted = await _countryRepository.AddAsync(country);
            var insertedCountry = await _countryRepository.GetByIdAsync(inserted.Id, false);
            var dto = _mapper.Map<CountryGetDto>(insertedCountry);
            return CustomResponse<CountryGetDto>.Success(StatusCodes.Status201Created, dto);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public Task<bool> AnyAsync(int id)
        {
            return _countryRepository.AnyIdAsync(id, false);
        }

        [IdCheckAspect]
        [CacheRemoveAspect("ICountryService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<NoData>> DeleteCountryAsync(int id)
        {
            var country = await _countryRepository.GetByIdAsync(id);
            await _countryRepository.DeleteAsync(country);
            return CustomResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        [CacheAddAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<List<CountryGetDto>>> GetCountriesAsync()
        {
            var countries = await _countryRepository.GetListAsync();
            if (countries != null && countries.Count > 0)
            {
                var dtoList = _mapper.Map<List<CountryGetDto>>(countries);
                return CustomResponse<List<CountryGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException(CountryErrorMessages.NotFoundCountries);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<CountryGetDto>> GetCountryByIdAsync(int id)
        {
            var country = await _countryRepository.GetByIdAsync(id, false);
            var dto = _mapper.Map<CountryGetDto>(country);
            return CustomResponse<CountryGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        [ValidationAspect(typeof(CountryPutDtoValidator))]
        [CacheRemoveAspect("ICountryService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<NoData>> UpdateCountryAsync(CountryPutDto countryPutDto)
        {
            var country = await _countryRepository.GetByIdAsync(countryPutDto.Id, false);
            if (country != null)
            {
                var updatedCountry = _mapper.Map<Country>(countryPutDto);
                updatedCountry.CreatedDate = country.CreatedDate;
                await _countryRepository.UpdateAsync(updatedCountry);
                return CustomResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException(CountryErrorMessages.NotFoundById);
        }
    }
}
