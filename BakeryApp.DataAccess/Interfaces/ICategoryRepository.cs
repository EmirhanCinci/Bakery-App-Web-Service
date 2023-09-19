using BakeryApp.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace BakeryApp.DataAccess.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category, int>
    {
        Task<Category?> GetSingleCategoryByIdWithFoodsAsync(int categoryId, params string[] includeList);
    }
}
