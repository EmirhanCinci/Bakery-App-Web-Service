using BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.Entities;
using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;

namespace BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class FoodPhotoRepository : EfBaseRepository<FoodPhoto, int, BakeryAppDbContext>, IFoodPhotoRepository
    {
        public FoodPhotoRepository(BakeryAppDbContext context) : base(context)
        {

        }
    }
}
