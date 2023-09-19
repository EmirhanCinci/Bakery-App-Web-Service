using AutoMapper;
using BakeryApp.Business.Constants.FoodPhoto;
using BakeryApp.Business.Interfaces;
using BakeryApp.Business.Validations.City;
using BakeryApp.Business.Validations.FoodPhoto;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.DTOs.FoodPhoto.Get;
using BakeryApp.Model.DTOs.FoodPhoto.Post;
using BakeryApp.Model.DTOs.FoodPhoto.Put;
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
    public class FoodPhotoService : IFoodPhotoService
    {
        private readonly IFoodPhotoRepository _foodPhotoRepository;
        private readonly IMapper _mapper;
        public FoodPhotoService(IFoodPhotoRepository foodPhotoRepository, IMapper mapper)
        {
            _foodPhotoRepository = foodPhotoRepository;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(FoodPhotoPostDtoValidator))]
        [CacheRemoveAspect("IFoodPhotoService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<FoodPhotoGetDto>> AddFoodPhotoAsync(FoodPhotoPostDto foodPhotoPostDto)
        {
            var foodPhoto = _mapper.Map<FoodPhoto>(foodPhotoPostDto);
            var inserted = await _foodPhotoRepository.AddAsync(foodPhoto);
            var insertedFoodPhoto = await _foodPhotoRepository.GetByIdAsync(inserted.Id, false, includeList: "Food");
            var dto = _mapper.Map<FoodPhotoGetDto>(insertedFoodPhoto);
            return CustomResponse<FoodPhotoGetDto>.Success(StatusCodes.Status201Created, dto);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<bool> AnyAsync(int id)
        {
            return await _foodPhotoRepository.AnyIdAsync(id, false);
        }

        [IdCheckAspect]
        [CacheRemoveAspect("IFoodPhotoService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<NoData>> DeleteFoodPhotoAsync(int id)
        {
            var foodPhoto = await _foodPhotoRepository.GetByIdAsync(id);
            await _foodPhotoRepository.DeleteAsync(foodPhoto);
            return CustomResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<FoodPhotoGetDto>> GetFoodPhotoByIdAsync(int id)
        {
            var foodPhoto = await _foodPhotoRepository.GetByIdAsync(id, false, false, "Food");
            var dto = _mapper.Map<FoodPhotoGetDto>(foodPhoto);
            return CustomResponse<FoodPhotoGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        [CacheAddAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<List<FoodPhotoGetDto>>> GetFoodPhotosAsync()
        {
            var foodPhotos = await _foodPhotoRepository.GetListAsync(includeList: "Food");
            if (foodPhotos != null && foodPhotos.Count > 0)
            {
                var dtoList = _mapper.Map<List<FoodPhotoGetDto>>(foodPhotos);
                return CustomResponse<List<FoodPhotoGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException(FoodPhotoErrorMessages.NotFoundFoodPhotos);
        }

        [ValidationAspect(typeof(CityPutDtoValidator))]
        [CacheRemoveAspect("IFoodPhotoService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<NoData>> UpdateFoodPhotoAsync(FoodPhotoPutDto foodPhotoPutDto)
        {
            var foodPhoto = await _foodPhotoRepository.GetByIdAsync(foodPhotoPutDto.Id, false);
            if (foodPhoto != null)
            {
                var updatedFoodPhoto = _mapper.Map<FoodPhoto>(foodPhotoPutDto);
                updatedFoodPhoto.CreatedDate = foodPhoto.CreatedDate;
                await _foodPhotoRepository.UpdateAsync(updatedFoodPhoto);
                return CustomResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException(FoodPhotoErrorMessages.NotFoundById);
        }
    }
}
