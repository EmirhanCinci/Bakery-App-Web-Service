using BakeryApp.Model.DTOs.Order.Get;
using BakeryApp.Model.DTOs.Order.Post;
using BakeryApp.Model.Entities;
using Infrastructure.Business.Interfaces;
using Infrastructure.Utilities.ApiResponses;

namespace BakeryApp.Business.Interfaces
{
    public interface IOrderService : IBaseService<Order, int>
    {
        Task<CustomResponse<List<OrderGetDto>>> GetOrdersAsync();
        Task<CustomResponse<OrderGetDto>> GetOrderByIdAsync(int id);
        Task<CustomResponse<OrderGetDto>> GetOrderByTrackingNumberAsync(Guid guid);
        Task<CustomResponse<OrderGetDto>> AddOrderAsync(OrderPostDto orderPostDto);
    }
}
