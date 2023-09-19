using BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.Entities;
using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;

namespace BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class UserBasketRepository : EfBaseRepository<UserBasket, int, BakeryAppDbContext>, IUserBasketRepository
    {
        public UserBasketRepository(BakeryAppDbContext context) : base(context)
        {

        }
    }
}
