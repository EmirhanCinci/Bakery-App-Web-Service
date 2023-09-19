using BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.Entities;
using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;

namespace BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class OrderDetailRepository : EfBaseRepository<OrderDetail, int, BakeryAppDbContext>, IOrderDetailRepository
    {
        public OrderDetailRepository(BakeryAppDbContext context) : base(context)
        {

        }
    }
}
