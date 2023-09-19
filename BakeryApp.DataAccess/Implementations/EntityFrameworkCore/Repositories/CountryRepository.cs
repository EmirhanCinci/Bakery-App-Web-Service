using BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.Entities;
using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;

namespace BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class CountryRepository : EfBaseRepository<Country, int, BakeryAppDbContext>, ICountryRepository
    {
        public CountryRepository(BakeryAppDbContext context) : base(context)
        {

        }

        public async Task<Country?> GetSingleCountryByIdWithCitiesAsync(int countryId, params string[] includeList)
        {
            return await GetAsync(prd => prd.Id == countryId, false, includeList: includeList);
        }
    }
}
