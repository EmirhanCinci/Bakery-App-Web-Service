using BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.Entities;
using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;

namespace BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class FoodCommentRepository : EfBaseRepository<FoodComment, int, BakeryAppDbContext>, IFoodCommentRepository
    {
        public FoodCommentRepository(BakeryAppDbContext context) : base(context)
        {

        }
    }
}
