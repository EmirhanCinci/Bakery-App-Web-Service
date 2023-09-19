using BakeryApp.Model.DTOs.UserBasket.Get;
using BakeryApp.Model.DTOs.UserBasket.Post;
using BakeryApp.Model.Entities;
using Infrastructure.Business.Interfaces;
using Infrastructure.Utilities.ApiResponses;

namespace BakeryApp.Business.Interfaces
{
    public interface IUserBasketService : IBaseService<UserBasket, int>
    {
        Task<CustomResponse<List<UserBasketGetDto>>> GetUserBasketsByUserIdAsync(int userId);
        Task<CustomResponse<List<UserBasketGetDto>>> GetUserBasketsByFoodIdAsync(int foodId);
        Task<CustomResponse<UserBasketGetDto>> GetUserBasketByIdAsync(int id);
        Task<CustomResponse<UserBasketGetDto>> AddUserBasketAsync(UserBasketPostDto userBasketPostDto);
        Task<CustomResponse<NoData>> DeleteUserBasketAsync(int id);
    }
}
