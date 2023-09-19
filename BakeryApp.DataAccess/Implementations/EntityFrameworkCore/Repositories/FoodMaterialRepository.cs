using BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.Entities;
using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;

namespace BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class FoodMaterialRepository : EfBaseRepository<FoodMaterial, int, BakeryAppDbContext>, IFoodMaterialRepository
    {
        public FoodMaterialRepository(BakeryAppDbContext context) : base(context)
        {

        }
    }
}
