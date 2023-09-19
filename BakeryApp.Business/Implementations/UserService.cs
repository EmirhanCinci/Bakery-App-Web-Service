using AutoMapper;
using BakeryApp.Business.Constants.User;
using BakeryApp.Business.Interfaces;
using BakeryApp.Business.Validations.User;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.DTOs.User.Get;
using BakeryApp.Model.DTOs.User.Post;
using BakeryApp.Model.DTOs.User.Put;
using Infrastructure.Aspects.Caching;
using Infrastructure.Aspects.IdParameter;
using Infrastructure.Aspects.Performance;
using Infrastructure.Aspects.Validation;
using Infrastructure.CrossCuttingConcerns.Exceptions;
using Infrastructure.Model.Implementations;
using Infrastructure.Utilities.ApiResponses;
using Infrastructure.Utilities.Security.Hashing;
using Microsoft.AspNetCore.Http;

namespace BakeryApp.Business.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [ValidationAspect(typeof(UserPostDtoValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<UserGetDto>> AddUserAsync(UserPostDto userPostDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userPostDto.Password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                FirstName = userPostDto.FirstName,
                LastName = userPostDto.LastName,
                Email = userPostDto.Email,
                CityId = userPostDto.CityId,
                GenderId = userPostDto.GenderId,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            var inserted = await _userRepository.AddAsync(user);
            string[] list = { "City", "Gender" };
            var insertedUser = await _userRepository.GetByIdAsync(inserted.Id, false, includeList: list);
            var dto = _mapper.Map<UserGetDto>(insertedUser);
            return CustomResponse<UserGetDto>.Success(StatusCodes.Status201Created, dto);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public Task<bool> AnyAsync(int id)
        {
            return _userRepository.AnyIdAsync(id, false);
        }

        [IdCheckAspect]
        [CacheRemoveAspect("IUserService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<NoData>> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            await _userRepository.DeleteAsync(user);
            return CustomResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<UserGetDto>> GetUserByIdAsync(int id)
        {
            string[] list = { "City", "Gender" };
            var user = await _userRepository.GetByIdAsync(id, false, includeList: list);
            var dto = _mapper.Map<UserGetDto>(user);
            return CustomResponse<UserGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        [CacheAddAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<List<UserGetDto>>> GetUsersAsync()
        {
            string[] list = { "City", "Gender" };
            var users = await _userRepository.GetListAsync(includeList: list);
            if (users != null && users.Count > 0)
            {
                var dtoList = _mapper.Map<List<UserGetDto>>(users);
                return CustomResponse<List<UserGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException(UserErrorMessages.NotFoundUsers);
        }

        [ValidationAspect(typeof(UserPutDtoValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<NoData>> UpdateUserAsync(UserPutDto userPutDto)
        {
            var user = await _userRepository.GetByIdAsync(userPutDto.Id, false);
            if (user != null)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(userPutDto.Password, out passwordHash, out passwordSalt);
                var userDto = new User()
                {
                    Id = user.Id,
                    FirstName = userPutDto.FirstName,
                    LastName = userPutDto.LastName,
                    Email = userPutDto.Email,
                    CityId = userPutDto.CityId,
                    GenderId = userPutDto.GenderId,
                    CreatedDate = user.CreatedDate,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };
                await _userRepository.UpdateAsync(userDto);
                return CustomResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException(UserErrorMessages.NotFoundById);
        }

        [ValidationAspect(typeof(UserPutDtoValidator))]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<UserGetDto>> UserLogInAsync(UserLoginPostDto userLoginGetDto)
        {
            var userToCheck = await _userRepository.GetUserByEmail(userLoginGetDto.Email, "City", "Gender");
            if (userToCheck == null)
            {
                throw new NotFoundException(UserErrorMessages.EmailNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userLoginGetDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                throw new BadRequestException(UserErrorMessages.WrongPassword);
            }
            var dto = _mapper.Map<UserGetDto>(userToCheck);
            return CustomResponse<UserGetDto>.Success(StatusCodes.Status200OK, dto);
        }
    }
}
