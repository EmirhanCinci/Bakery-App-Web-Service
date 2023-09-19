using BakeryApp.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace BakeryApp.DataAccess.Interfaces
{
    public interface IUserBasketRepository : IBaseRepository<UserBasket, int>
    {
    }
}
