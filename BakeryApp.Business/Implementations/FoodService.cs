using AutoMapper;
using BakeryApp.Business.Constants.Food;
using BakeryApp.Business.Interfaces;
using BakeryApp.Business.Validations.Food;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.DTOs.Food.Get;
using BakeryApp.Model.DTOs.Food.Post;
using BakeryApp.Model.DTOs.Food.Put;
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
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;
        public FoodService(IFoodRepository foodRepository, IMapper mapper)
        {
            _foodRepository = foodRepository;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(FoodPostDtoValidator))]
        [CacheRemoveAspect("IFoodService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<FoodGetDto>> AddFoodAsync(FoodPostDto foodPostDto)
        {
            var food = _mapper.Map<Food>(foodPostDto);
            var inserted = await _foodRepository.AddAsync(food);
            var insertedFood = await _foodRepository.GetByIdAsync(inserted.Id, false, includeList: "Category");
            var dto = _mapper.Map<FoodGetDto>(insertedFood);
            return CustomResponse<FoodGetDto>.Success(StatusCodes.Status201Created, dto);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<bool> AnyAsync(int id)
        {
            return await _foodRepository.AnyIdAsync(id, false);
        }

        [IdCheckAspect]
        [CacheRemoveAspect("IFoodService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<NoData>> DeleteFoodAsync(int id)
        {
            var food = await _foodRepository.GetByIdAsync(id);
            await _foodRepository.DeleteAsync(food);
            return CustomResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<SingleFoodGetDto>> GetFoodByIdAsync(int id)
        {
            string[] list = { "Category", "FoodMaterials", "FoodComments", "FoodComments.User", "FoodPhotos" };
            var food = await _foodRepository.GetByIdAsync(id, false, includeList: list);
            var dto = _mapper.Map<SingleFoodGetDto>(food);
            return CustomResponse<SingleFoodGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        [CacheAddAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<List<FoodGetDto>>> GetFoodsAsync()
        {
            var foods = await _foodRepository.GetListAsync(includeList: "Category");
            if (foods != null && foods.Count > 0)
            {
                var dtoList = _mapper.Map<List<FoodGetDto>>(foods);
                return CustomResponse<List<FoodGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException(FoodErrorMessages.NotFoundFoods);
        }

        [ValidationAspect(typeof(FoodPutDtoValidator))]
        [CacheRemoveAspect("IFoodService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<NoData>> UpdateFoodAsync(FoodPutDto foodPutDto)
        {
            var food = await _foodRepository.GetByIdAsync(foodPutDto.Id, false);
            if (food != null)
            {
                var updatedFood = _mapper.Map<Food>(foodPutDto);
                updatedFood.CreatedDate = food.CreatedDate;
                await _foodRepository.UpdateAsync(updatedFood);
                return CustomResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException(FoodErrorMessages.NotFoundById);
        }
    }
}
