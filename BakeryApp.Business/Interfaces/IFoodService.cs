using BakeryApp.Model.DTOs.Food.Get;
using BakeryApp.Model.DTOs.Food.Post;
using BakeryApp.Model.DTOs.Food.Put;
using BakeryApp.Model.Entities;
using Infrastructure.Business.Interfaces;
using Infrastructure.Utilities.ApiResponses;

namespace BakeryApp.Business.Interfaces
{
    public interface IFoodService : IBaseService<Food, int>
    {
        Task<CustomResponse<List<FoodGetDto>>> GetFoodsAsync();
        Task<CustomResponse<SingleFoodGetDto>> GetFoodByIdAsync(int id);
        Task<CustomResponse<FoodGetDto>> AddFoodAsync(FoodPostDto foodPostDto);
        Task<CustomResponse<NoData>> UpdateFoodAsync(FoodPutDto foodPutDto);
        Task<CustomResponse<NoData>> DeleteFoodAsync(int id);
    }
}
