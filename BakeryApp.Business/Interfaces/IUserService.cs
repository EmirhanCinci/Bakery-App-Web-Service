using BakeryApp.Model.DTOs.User.Get;
using BakeryApp.Model.DTOs.User.Post;
using BakeryApp.Model.DTOs.User.Put;
using Infrastructure.Business.Interfaces;
using Infrastructure.Model.Implementations;
using Infrastructure.Utilities.ApiResponses;

namespace BakeryApp.Business.Interfaces
{
    public interface IUserService : IBaseService<User, int>
    {
        Task<CustomResponse<List<UserGetDto>>> GetUsersAsync();
        Task<CustomResponse<UserGetDto>> GetUserByIdAsync(int id); 
        Task<CustomResponse<UserGetDto>> UserLogInAsync(UserLoginPostDto userLoginGetDto);
        Task<CustomResponse<UserGetDto>> AddUserAsync(UserPostDto userPostDto);
        Task<CustomResponse<NoData>> DeleteUserAsync(int id);
        Task<CustomResponse<NoData>> UpdateUserAsync(UserPutDto userPutDto);
    }
}
