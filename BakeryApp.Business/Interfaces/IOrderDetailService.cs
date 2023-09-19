using BakeryApp.Model.DTOs.OrderDetail.Get;
using BakeryApp.Model.DTOs.OrderDetail.Post;
using BakeryApp.Model.Entities;
using Infrastructure.Business.Interfaces;
using Infrastructure.Utilities.ApiResponses;

namespace BakeryApp.Business.Interfaces
{
    public interface IOrderDetailService : IBaseService<OrderDetail, int>
    {
        Task<CustomResponse<OrderDetailGetDto>> GetOrderDetailByIdAsync(int id);
        Task<CustomResponse<List<OrderDetailGetDto>>> GetOrderDetailsByOrderIdAsync(int orderId);
        Task<CustomResponse<OrderDetailGetDto>> AddOrderDetailAsync(OrderDetailPostDto orderDetailPostDto);
    }
}
