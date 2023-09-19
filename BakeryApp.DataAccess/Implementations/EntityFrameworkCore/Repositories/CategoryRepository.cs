using BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.Entities;
using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;

namespace BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class CategoryRepository : EfBaseRepository<Category, int, BakeryAppDbContext>, ICategoryRepository
    {
        public CategoryRepository(BakeryAppDbContext context) : base(context)
        {

        }

        public async Task<Category?> GetSingleCategoryByIdWithFoodsAsync(int categoryId, params string[] includeList)
        {
            return await GetAsync(predicate: prd => prd.Id == categoryId, enableTracking: false, includeList: includeList);
        }
    }
}
