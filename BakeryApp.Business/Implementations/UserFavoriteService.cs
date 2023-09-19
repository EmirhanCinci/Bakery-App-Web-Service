using AutoMapper;
using BakeryApp.Business.Constants.UserFavorite;
using BakeryApp.Business.Interfaces;
using BakeryApp.Business.Validations.UserFavorite;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.DTOs.UserFavorite.Get;
using BakeryApp.Model.DTOs.UserFavorite.Post;
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
    public class UserFavoriteService : IUserFavoriteService
    {
        private readonly IUserFavoriteRepository _userFavoriteRepository;
        private readonly IMapper _mapper;
        public UserFavoriteService(IUserFavoriteRepository userFavoriteRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userFavoriteRepository = userFavoriteRepository;
        }

        [ValidationAspect(typeof(UserFavoritePostDtoValidator))]
        [CacheRemoveAspect("IUserFavoriteService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<UserFavoriteGetDto>> AddUserFavoriteAsync(UserFavoritePostDto userFavoritePostDto)
        {
            var userFavorite = _mapper.Map<UserFavorite>(userFavoritePostDto);
            var inserted = await _userFavoriteRepository.AddAsync(userFavorite);
            var insertedUserFavorite = await _userFavoriteRepository.GetByIdAsync(inserted.Id, false, false, "Food", "User");
            var dto = _mapper.Map<UserFavoriteGetDto>(insertedUserFavorite);
            return CustomResponse<UserFavoriteGetDto>.Success(StatusCodes.Status201Created, dto);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<bool> AnyAsync(int id)
        {
            return await _userFavoriteRepository.AnyIdAsync(id, false);
        }

        [IdCheckAspect]
        [CacheRemoveAspect("IUserFavoriteService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<NoData>> DeleteUserFavoriteAsync(int id)
        {
            var userFavorite = await _userFavoriteRepository.GetByIdAsync(id);
            await _userFavoriteRepository.DeleteAsync(userFavorite);
            return CustomResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<UserFavoriteGetDto>> GetUserFavoriteByIdAsync(int id)
        {
            var userFavorite = await _userFavoriteRepository.GetByIdAsync(id, false, false, "Food", "User");
            var dto = _mapper.Map<UserFavoriteGetDto>(userFavorite);
            return CustomResponse<UserFavoriteGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<List<UserFavoriteGetDto>>> GetUserFavoritesByFoodIdAsync(int foodId)
        {
            string[] list = { "Food", "User" };
            var userFavorites = await _userFavoriteRepository.GetListAsync(prd => prd.FoodId == foodId, includeList: list);
            if (userFavorites != null && userFavorites.Count > 0)
            {
                var dtoList = _mapper.Map<List<UserFavoriteGetDto>>(userFavorites);
                return CustomResponse<List<UserFavoriteGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException(UserFavoriteErrorMessages.NotFoundUserFavorites);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<List<UserFavoriteGetDto>>> GetUserFavoritesByUserIdAsync(int userId)
        {
            string[] list = { "Food", "User" };
            var userFavorites = await _userFavoriteRepository.GetListAsync(prd => prd.UserId == userId, includeList: list);
            if (userFavorites != null && userFavorites.Count > 0)
            {
                var dtoList = _mapper.Map<List<UserFavoriteGetDto>>(userFavorites);
                return CustomResponse<List<UserFavoriteGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException(UserFavoriteErrorMessages.NotFoundUserFavorites);
        }
    }
}
