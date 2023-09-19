using BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.Entities;
using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;

namespace BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class CityRepository : EfBaseRepository<City, int, BakeryAppDbContext>, ICityRepository
    {
        public CityRepository(BakeryAppDbContext context) : base(context)
        {

        }

        public async Task<City?> GetSingleCityByIdWithUsersAsync(int cityId, params string[] includeList)
        {
            return await GetAsync(prd => prd.Id == cityId, false, includeList: includeList);
        }
    }
}
