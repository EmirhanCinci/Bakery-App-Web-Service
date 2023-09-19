using Infrastructure.DataAccess.Interfaces;
using Infrastructure.Model.Implementations;

namespace BakeryApp.DataAccess.Interfaces
{
    public interface IUserRepository : IBaseRepository<User, int>
    {
       Task<User?> GetUserByEmail(string email, params string[] includeList);
    }
}
