using BakeryApp.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace BakeryApp.DataAccess.Interfaces
{
    public interface IFoodCommentRepository : IBaseRepository<FoodComment, int>
    {
    }
}
