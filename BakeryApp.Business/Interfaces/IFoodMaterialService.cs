using BakeryApp.Model.DTOs.FoodMaterial.Get;
using BakeryApp.Model.DTOs.FoodMaterial.Post;
using BakeryApp.Model.DTOs.FoodMaterial.Put;
using BakeryApp.Model.Entities;
using Infrastructure.Business.Interfaces;
using Infrastructure.Utilities.ApiResponses;

namespace BakeryApp.Business.Interfaces
{
    public interface IFoodMaterialService : IBaseService<FoodMaterial, int>
    {
        Task<CustomResponse<List<FoodMaterialGetDto>>> GetFoodMaterialsAsync();
        Task<CustomResponse<FoodMaterialGetDto>> GetFoodMaterialByIdAsync(int id);
        Task<CustomResponse<FoodMaterialGetDto>> AddFoodMaterialAsync(FoodMaterialPostDto foodMaterialPostDto);
        Task<CustomResponse<NoData>> UpdateFoodMaterialAsync(FoodMaterialPutDto foodMaterialPutDto);
        Task<CustomResponse<NoData>> DeleteFoodMaterialAsync(int id);
    }
}
