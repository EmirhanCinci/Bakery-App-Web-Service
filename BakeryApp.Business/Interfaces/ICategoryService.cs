using BakeryApp.Model.DTOs.Category.Get;
using BakeryApp.Model.DTOs.Category.Post;
using BakeryApp.Model.DTOs.Category.Put;
using BakeryApp.Model.Entities;
using Infrastructure.Business.Interfaces;
using Infrastructure.Utilities.ApiResponses;

namespace BakeryApp.Business.Interfaces
{
    public interface ICategoryService : IBaseService<Category, int>
    {
        Task<CustomResponse<List<CategoryGetDto>>> GetAllCategoriesAsync();
        Task<CustomResponse<CategoryGetDto>> GetCategoryByIdAsync(int id);
        Task<CustomResponse<CategoryGetDto>> AddCategoryAsync(CategoryPostDto categoryPostDto);
        Task<CustomResponse<NoData>> UpdateCategoryAsync(CategoryPutDto categoryPutDto);
        Task<CustomResponse<NoData>> DeleteCategoryAsync(int id);
    }
}
