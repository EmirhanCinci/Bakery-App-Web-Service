using BakeryApp.Model.DTOs.FoodComment.Get;
using BakeryApp.Model.DTOs.FoodComment.Post;
using BakeryApp.Model.DTOs.FoodComment.Put;
using BakeryApp.Model.Entities;
using Infrastructure.Business.Interfaces;
using Infrastructure.Utilities.ApiResponses;

namespace BakeryApp.Business.Interfaces
{
    public interface IFoodCommentService : IBaseService<FoodComment, int>
    {
        Task<CustomResponse<List<FoodCommentGetDto>>> GetFoodCommentsAsync();
        Task<CustomResponse<FoodCommentGetDto>> GetFoodCommentByIdAsync(int id);
        Task<CustomResponse<FoodCommentGetDto>> AddFoodCommentAsync(FoodCommentPostDto foodCommentPostDto);
        Task<CustomResponse<NoData>> UpdateFoodCommentAsync(FoodCommentPutDto foodCommentPutDto);
        Task<CustomResponse<NoData>> DeleteFoodCommentAsync(int id);
    }
}
