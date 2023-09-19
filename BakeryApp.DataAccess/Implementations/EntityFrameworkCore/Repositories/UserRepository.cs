using BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using BakeryApp.DataAccess.Interfaces;
using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;
using Infrastructure.Model.Implementations;

namespace BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class UserRepository : EfBaseRepository<User, int, BakeryAppDbContext>, IUserRepository
    {
        public UserRepository(BakeryAppDbContext context) : base(context)
        {

        }

        public async Task<User?> GetUserByEmail(string email, params string[] includeList)
        {
            return await GetAsync(prd => prd.Email == email, false, false, includeList);
        }
    }
}
