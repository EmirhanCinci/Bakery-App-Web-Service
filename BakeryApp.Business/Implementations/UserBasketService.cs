using AutoMapper;
using BakeryApp.Business.Constants.UserBasket;
using BakeryApp.Business.Interfaces;
using BakeryApp.Business.Validations.UserBasket;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.DTOs.UserBasket.Get;
using BakeryApp.Model.DTOs.UserBasket.Post;
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
    public class UserBasketService : IUserBasketService
    {
        private readonly IUserBasketRepository _userBasketRepository;
        private readonly IMapper _mapper;
        public UserBasketService(IUserBasketRepository userBasketRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userBasketRepository = userBasketRepository;
        }

        [ValidationAspect(typeof(UserBasketPostDtoValidator))]
        [CacheRemoveAspect("IUserBasketService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<UserBasketGetDto>> AddUserBasketAsync(UserBasketPostDto userBasketPostDto)
        {
            var userBasket = _mapper.Map<UserBasket>(userBasketPostDto);
            var inserted = await _userBasketRepository.AddAsync(userBasket);
            var insertedUserBasket = await _userBasketRepository.GetByIdAsync(inserted.Id, false, false, "Food", "User");
            var dto = _mapper.Map<UserBasketGetDto>(insertedUserBasket);
            return CustomResponse<UserBasketGetDto>.Success(StatusCodes.Status201Created, dto);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<bool> AnyAsync(int id)
        {
            return await _userBasketRepository.AnyIdAsync(id, false);
        }

        [IdCheckAspect]
        [CacheRemoveAspect("IUserBasketService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<NoData>> DeleteUserBasketAsync(int id)
        {
            var userBasket = await _userBasketRepository.GetByIdAsync(id);
            await _userBasketRepository.DeleteAsync(userBasket);
            return CustomResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<UserBasketGetDto>> GetUserBasketByIdAsync(int id)
        {
            var userBasket = await _userBasketRepository.GetByIdAsync(id, false, false, "Food", "User");
            var dto = _mapper.Map<UserBasketGetDto>(userBasket);
            return CustomResponse<UserBasketGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<List<UserBasketGetDto>>> GetUserBasketsByFoodIdAsync(int foodId)
        {
            string[] list = { "Food", "User" };
            var userBaskets = await _userBasketRepository.GetListAsync(prd => prd.FoodId == foodId, includeList: list);
            if (userBaskets != null && userBaskets.Count > 0)
            {
                var dtoList = _mapper.Map<List<UserBasketGetDto>>(userBaskets);
                return CustomResponse<List<UserBasketGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException(UserBasketErrorMessages.NotFoundUserBaskets);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<List<UserBasketGetDto>>> GetUserBasketsByUserIdAsync(int userId)
        {
            string[] list = { "Food", "User" };
            var userBaskets = await _userBasketRepository.GetListAsync(prd => prd.UserId == userId, includeList: list);
            if (userBaskets != null && userBaskets.Count > 0)
            {
                var dtoList = _mapper.Map<List<UserBasketGetDto>>(userBaskets);
                return CustomResponse<List<UserBasketGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException(UserBasketErrorMessages.NotFoundUserBaskets);
        }
    }
}
