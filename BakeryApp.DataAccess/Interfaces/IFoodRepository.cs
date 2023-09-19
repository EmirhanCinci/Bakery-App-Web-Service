using BakeryApp.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace BakeryApp.DataAccess.Interfaces
{
    public interface IFoodRepository : IBaseRepository<Food, int>
    {

    }
}
