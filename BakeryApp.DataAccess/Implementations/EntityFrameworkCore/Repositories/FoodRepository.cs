using BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.Entities;
using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;

namespace BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class FoodRepository : EfBaseRepository<Food, int, BakeryAppDbContext>, IFoodRepository
    {
        public FoodRepository(BakeryAppDbContext context) : base(context)
        {

        }
    }
}
