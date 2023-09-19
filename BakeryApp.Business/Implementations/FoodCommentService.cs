using AutoMapper;
using BakeryApp.Business.Constants.FoodComment;
using BakeryApp.Business.Interfaces;
using BakeryApp.Business.Validations.FoodComment;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.DTOs.FoodComment.Get;
using BakeryApp.Model.DTOs.FoodComment.Post;
using BakeryApp.Model.DTOs.FoodComment.Put;
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
    public class FoodCommentService : IFoodCommentService
    {
        private readonly IFoodCommentRepository _foodCommentRepository;
        private readonly IMapper _mapper;
        public FoodCommentService(IFoodCommentRepository foodCommentRepository, IMapper mapper)
        {
            _foodCommentRepository = foodCommentRepository;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(FoodCommentPostDtoValidator))]
        [CacheRemoveAspect("IFoodCommentService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<FoodCommentGetDto>> AddFoodCommentAsync(FoodCommentPostDto foodCommentPostDto)
        {
            var foodComment = _mapper.Map<FoodComment>(foodCommentPostDto);
            var inserted = await _foodCommentRepository.AddAsync(foodComment);
            var insertedFoodComment = await _foodCommentRepository.GetByIdAsync(inserted.Id, false, false, "Food", "User");
            var dto = _mapper.Map<FoodCommentGetDto>(insertedFoodComment);
            return CustomResponse<FoodCommentGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<bool> AnyAsync(int id)
        {
            return await _foodCommentRepository.AnyIdAsync(id, false);
        }

        [IdCheckAspect]
        [CacheRemoveAspect("IFoodCommentService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<NoData>> DeleteFoodCommentAsync(int id)
        {
            var foodComment = await _foodCommentRepository.GetByIdAsync(id, true, false, "Food", "User");
            await _foodCommentRepository.DeleteAsync(foodComment);
            return CustomResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<FoodCommentGetDto>> GetFoodCommentByIdAsync(int id)
        {
            var foodComment = await _foodCommentRepository.GetByIdAsync(id, false, false, "User", "Food");
            var dto = _mapper.Map<FoodCommentGetDto>(foodComment);
            return CustomResponse<FoodCommentGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        [CacheAddAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<List<FoodCommentGetDto>>> GetFoodCommentsAsync()
        {
            string[] list = { "User", "Food" };
            var foodComments = await _foodCommentRepository.GetListAsync(includeList: list);
            if (foodComments != null && foodComments.Count > 0)
            {
                var dtoList = _mapper.Map<List<FoodCommentGetDto>>(foodComments);
                return CustomResponse<List<FoodCommentGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException(FoodCommentErrorMessages.NotFoundComments);
        }

        [ValidationAspect(typeof(FoodCommentPutDtoValidator))]
        [CacheRemoveAspect("IFoodCommentService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<NoData>> UpdateFoodCommentAsync(FoodCommentPutDto foodCommentPutDto)
        {
            var foodComment = await _foodCommentRepository.GetByIdAsync(foodCommentPutDto.Id, false);
            if (foodComment != null)
            {
                var updatedFoodComment = _mapper.Map<FoodComment>(foodCommentPutDto);
                updatedFoodComment.CreatedDate = foodComment.CreatedDate;
                await _foodCommentRepository.UpdateAsync(updatedFoodComment);
                return CustomResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException(FoodCommentErrorMessages.NotFoundById);
        }
    }
}
