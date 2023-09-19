using AutoMapper;
using BakeryApp.Business.Constants.OrderDetail;
using BakeryApp.Business.Interfaces;
using BakeryApp.Business.Validations.OrderDetail;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.DTOs.OrderDetail.Get;
using BakeryApp.Model.DTOs.OrderDetail.Post;
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
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;
        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _mapper = mapper;
            _orderDetailRepository = orderDetailRepository;
        }

        [ValidationAspect(typeof(OrderDetailPostDtoValidator))]
        [CacheRemoveAspect("ICityService.Get")]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<OrderDetailGetDto>> AddOrderDetailAsync(OrderDetailPostDto orderDetailPostDto)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailPostDto);
            var inserted = await _orderDetailRepository.AddAsync(orderDetail);
            var insertedOrderDetail = await _orderDetailRepository.GetByIdAsync(inserted.Id, false, false, "Order", "Food");
            var dto = _mapper.Map<OrderDetailGetDto>(insertedOrderDetail);
            return CustomResponse<OrderDetailGetDto>.Success(StatusCodes.Status201Created, dto);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<bool> AnyAsync(int id)
        {
            return await _orderDetailRepository.AnyIdAsync(id, false);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<OrderDetailGetDto>> GetOrderDetailByIdAsync(int id)
        {
            var order = await _orderDetailRepository.GetByIdAsync(id, false, false, "Order", "Food");
            var dto = _mapper.Map<OrderDetailGetDto>(order);
            return CustomResponse<OrderDetailGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        [PerformanceAspect(5)]
        public async Task<CustomResponse<List<OrderDetailGetDto>>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            var order = await _orderDetailRepository.GetAsync(prd => prd.OrderId == orderId, false, false, "Order", "Food");
            if (order != null)
            {
                var dto = _mapper.Map<List<OrderDetailGetDto>>(order);
                return CustomResponse<List<OrderDetailGetDto>>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(OrderDetailErrorMessages.NotFoundById);
        }
    }
}
