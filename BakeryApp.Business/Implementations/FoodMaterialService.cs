using AutoMapper;
using BakeryApp.Business.Constants.FoodMaterial;
using BakeryApp.Business.Interfaces;
using BakeryApp.Business.Validations.FoodMaterial;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.DTOs.FoodMaterial.Get;
using BakeryApp.Model.DTOs.FoodMaterial.Post;
using BakeryApp.Model.DTOs.FoodMaterial.Put;
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
    public class FoodMaterialService : IFoodMaterialService
    {
        private readonly IFoodMaterialRepository _foodMaterialRepository;
        private readonly IMapper _mapper;
        public FoodMaterialService(IFoodMaterialRepository foodMaterialRepository, IMapper mapper)
        {
            _foodMaterialRepository = foodMaterialRepository;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(FoodMaterialPostDtoValidator))]
        [CacheRemoveAspect("IFoodMaterialService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<FoodMaterialGetDto>> AddFoodMaterialAsync(FoodMaterialPostDto foodMaterialPostDto)
        {
            var foodMaterial = _mapper.Map<FoodMaterial>(foodMaterialPostDto);
            var inserted = await _foodMaterialRepository.AddAsync(foodMaterial);
            var insertedFoodMaterial = await _foodMaterialRepository.GetByIdAsync(inserted.Id, false, includeList: "Food");
            var dto = _mapper.Map<FoodMaterialGetDto>(insertedFoodMaterial);
            return CustomResponse<FoodMaterialGetDto>.Success(StatusCodes.Status201Created, dto);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<bool> AnyAsync(int id)
        {
            return await _foodMaterialRepository.AnyIdAsync(id, false);
        }

        [IdCheckAspect]
        [CacheRemoveAspect("IFoodMaterialService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<NoData>> DeleteFoodMaterialAsync(int id)
        {
            var foodMaterial = await _foodMaterialRepository.GetByIdAsync(id);
            await _foodMaterialRepository.DeleteAsync(foodMaterial);
            return CustomResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<FoodMaterialGetDto>> GetFoodMaterialByIdAsync(int id)
        {
            var foodMaterial = await _foodMaterialRepository.GetByIdAsync(id, false);
            var dto = _mapper.Map<FoodMaterialGetDto>(foodMaterial);
            return CustomResponse<FoodMaterialGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        [CacheAddAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<List<FoodMaterialGetDto>>> GetFoodMaterialsAsync()
        {
            var foodMaterials = await _foodMaterialRepository.GetListAsync();
            if (foodMaterials != null && foodMaterials.Count > 0)
            {
                var dtoList = _mapper.Map<List<FoodMaterialGetDto>>(foodMaterials);
                return CustomResponse<List<FoodMaterialGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException(FoodMaterialErrorMessages.NotFoundFoodMaterials);
        }

        [ValidationAspect(typeof(FoodMaterialPutDtoValidator))]
        [CacheRemoveAspect("IFoodMaterialService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<NoData>> UpdateFoodMaterialAsync(FoodMaterialPutDto foodMaterialPutDto)
        {
            var foodMaterial = await _foodMaterialRepository.GetByIdAsync(foodMaterialPutDto.Id, false);
            if (foodMaterial != null)
            {
                var updatedFoodMaterial = _mapper.Map<FoodMaterial>(foodMaterialPutDto);
                updatedFoodMaterial.CreatedDate = foodMaterial.CreatedDate;
                await _foodMaterialRepository.UpdateAsync(updatedFoodMaterial);
                return CustomResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException(FoodMaterialErrorMessages.NotFoundById);
        }
    }
}
