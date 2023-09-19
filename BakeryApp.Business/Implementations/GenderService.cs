using AutoMapper;
using BakeryApp.Business.Constants.Gender;
using BakeryApp.Business.Interfaces;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.DTOs.Gender.Get;
using Infrastructure.Aspects.Caching;
using Infrastructure.Aspects.IdParameter;
using Infrastructure.Aspects.Performance;
using Infrastructure.CrossCuttingConcerns.Exceptions;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;

namespace BakeryApp.Business.Implementations
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IMapper _mapper;
        public GenderService(IGenderRepository genderRepository, IMapper mapper)
        {
            _genderRepository = genderRepository;
            _mapper = mapper;
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public Task<bool> AnyAsync(int id)
        {
            return _genderRepository.AnyIdAsync(id, false);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<GenderGetDto>> GetGenderByIdAsync(int id)
        {
            var gender = await _genderRepository.GetByIdAsync(id);
            var dto = _mapper.Map<GenderGetDto>(gender);
            return CustomResponse<GenderGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        [CacheAddAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<List<GenderGetDto>>> GetGendersAsync()
        {
            var genders = await _genderRepository.GetListAsync();
            if (genders != null && genders.Count > 0)
            {
                var dtoList = _mapper.Map<List<GenderGetDto>>(genders);
                return CustomResponse<List<GenderGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException(GenderErrorMessages.NotFoundGenders);
        }
    }
}
