using BakeryApp.Business.Interfaces;
using BakeryApp.Model.DTOs.OrderDetail.Get;
using BakeryApp.Model.DTOs.OrderDetail.Post;
using BakeryApp.Model.Entities;
using BakeryApp.WebApi.Filters;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace BakeryApp.WebApi.Controllers
{
    public class OrderDetailsController : BaseController
    {
        private readonly IOrderDetailService _orderDetailService;
        public OrderDetailsController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<List<OrderDetailGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> GetOrderDetailsByOrderId([FromRoute] int id)
        {
            var response = await _orderDetailService.GetOrderDetailsByOrderIdAsync(id);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<OrderDetailGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpGet("{id:int}")]
        [ServiceFilter(typeof(NotFoundFilter<OrderDetail, int>))]
        public async Task<IActionResult> GetOrderDetailsById([FromRoute] int id)
        {
            var response = await _orderDetailService.GetOrderDetailByIdAsync(id);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomResponse<OrderDetailGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> AddOrderDetail([FromBody] OrderDetailPostDto orderDetailPostDto)
        {
            var response = await _orderDetailService.AddOrderDetailAsync(orderDetailPostDto);
            return SendResponse(response);
        }
    }
}
