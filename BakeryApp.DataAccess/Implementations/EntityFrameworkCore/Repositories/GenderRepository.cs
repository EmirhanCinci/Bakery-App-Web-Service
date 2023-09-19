using BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.Entities;
using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;

namespace BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class GenderRepository : EfBaseRepository<Gender, int, BakeryAppDbContext>, IGenderRepository
    {
        public GenderRepository(BakeryAppDbContext context) : base(context)
        {

        }

        public async Task<Gender?> GetSingleGenderByIdWithUsersAsync(int genderId, params string[] includeList)
        {
            return await GetAsync(prd => prd.Id == genderId, false, includeList: includeList);
        }
    }
}
