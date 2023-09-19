using BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.Entities;
using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;

namespace BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class OrderRepository : EfBaseRepository<Order, int, BakeryAppDbContext>, IOrderRepository
    {
        public OrderRepository(BakeryAppDbContext context) : base(context)
        {

        }
    }
}
