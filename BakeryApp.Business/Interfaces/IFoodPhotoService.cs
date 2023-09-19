using BakeryApp.Model.DTOs.FoodPhoto.Get;
using BakeryApp.Model.DTOs.FoodPhoto.Post;
using BakeryApp.Model.DTOs.FoodPhoto.Put;
using BakeryApp.Model.Entities;
using Infrastructure.Business.Interfaces;
using Infrastructure.Utilities.ApiResponses;

namespace BakeryApp.Business.Interfaces
{
    public interface IFoodPhotoService : IBaseService<FoodPhoto, int>
    {
        Task<CustomResponse<List<FoodPhotoGetDto>>> GetFoodPhotosAsync();
        Task<CustomResponse<FoodPhotoGetDto>> GetFoodPhotoByIdAsync(int id);
        Task<CustomResponse<FoodPhotoGetDto>> AddFoodPhotoAsync(FoodPhotoPostDto foodPhotoPostDto);
        Task<CustomResponse<NoData>> UpdateFoodPhotoAsync(FoodPhotoPutDto foodPhotoPutDto);
        Task<CustomResponse<NoData>> DeleteFoodPhotoAsync(int id);
    }
}
