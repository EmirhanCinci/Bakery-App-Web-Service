using BakeryApp.Model.DTOs.UserFavorite.Get;
using BakeryApp.Model.DTOs.UserFavorite.Post;
using BakeryApp.Model.Entities;
using Infrastructure.Business.Interfaces;
using Infrastructure.Utilities.ApiResponses;

namespace BakeryApp.Business.Interfaces
{
    public interface IUserFavoriteService : IBaseService<UserFavorite, int>
    {
        Task<CustomResponse<List<UserFavoriteGetDto>>> GetUserFavoritesByUserIdAsync(int userId);
        Task<CustomResponse<List<UserFavoriteGetDto>>> GetUserFavoritesByFoodIdAsync(int foodId);
        Task<CustomResponse<UserFavoriteGetDto>> GetUserFavoriteByIdAsync(int id);
        Task<CustomResponse<UserFavoriteGetDto>> AddUserFavoriteAsync(UserFavoritePostDto userFavoritePostDto);
        Task<CustomResponse<NoData>> DeleteUserFavoriteAsync(int id);
    }
}
