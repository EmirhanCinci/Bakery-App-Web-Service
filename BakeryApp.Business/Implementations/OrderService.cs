using AutoMapper;
using BakeryApp.Business.Constants.Order;
using BakeryApp.Business.Interfaces;
using BakeryApp.Business.Validations.Order;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.DTOs.Order.Get;
using BakeryApp.Model.DTOs.Order.Post;
using BakeryApp.Model.Entities;
using Infrastructure.Aspects.Caching;
using Infrastructure.Aspects.IdParameter;
using Infrastructure.Aspects.Performance;
using Infrastructure.Aspects.Validation;
using Infrastructure.CrossCuttingConcerns.Exceptions;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;

namespace BakeryApp.Business.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        [ValidationAspect(typeof(OrderPostDtoValidator))]
        [CacheRemoveAspect("IOrderService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<OrderGetDto>> AddOrderAsync(OrderPostDto orderPostDto)
        {
            var order = _mapper.Map<Order>(orderPostDto);
            order.TrackingNumber = Guid.NewGuid();
            var inserted = await _orderRepository.AddAsync(order);
            string[] list = { "OrderDetails", "User" };
            var insertedOrder = await _orderRepository.GetByIdAsync(inserted.Id, includeList: list);
            var dto = _mapper.Map<OrderGetDto>(insertedOrder);
            return CustomResponse<OrderGetDto>.Success(StatusCodes.Status201Created, dto);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<bool> AnyAsync(int id)
        {
            return await _orderRepository.AnyIdAsync(id, false);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<OrderGetDto>> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id, false, false, "OrderDetails", "User");
            var dto = _mapper.Map<OrderGetDto>(order);
            return CustomResponse<OrderGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        [PerformanceAspect(5)]
        public async Task<CustomResponse<OrderGetDto>> GetOrderByTrackingNumberAsync(Guid guid)
        {
            string[] list = { "OrderDetails", "User" };
            var order = await _orderRepository.GetAsync(prd => prd.TrackingNumber == guid, includeList: list);
            var dto = _mapper.Map<OrderGetDto>(order);
            return CustomResponse<OrderGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        [CacheAddAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<List<OrderGetDto>>> GetOrdersAsync()
        {
            string[] list = { "OrderDetails", "User" };
            var orders = await _orderRepository.GetListAsync(includeList: list);
            if (orders != null && orders.Count > 0)
            {
                var dtoList = _mapper.Map<List<OrderGetDto>>(orders);
                return CustomResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException(OrderErrorMessages.NotFoundOrders);
        }
    }
}
