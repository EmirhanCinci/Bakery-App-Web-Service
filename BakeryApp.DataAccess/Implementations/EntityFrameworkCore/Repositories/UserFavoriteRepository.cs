using BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.Entities;
using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;

namespace BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class UserFavoriteRepository : EfBaseRepository<UserFavorite, int, BakeryAppDbContext>, IUserFavoriteRepository
    {
        public UserFavoriteRepository(BakeryAppDbContext context) : base(context)
        {

        }
    }
}
