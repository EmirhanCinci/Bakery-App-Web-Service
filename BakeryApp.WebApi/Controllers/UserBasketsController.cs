using BakeryApp.Business.Interfaces;
using BakeryApp.Model.DTOs.UserBasket.Get;
using BakeryApp.Model.DTOs.UserBasket.Post;
using BakeryApp.Model.Entities;
using BakeryApp.WebApi.Filters;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace BakeryApp.WebApi.Controllers
{
    public class UserBasketsController : BaseController
    {
        private readonly IUserBasketService _userBasketService;
        public UserBasketsController(IUserBasketService userBasketService)
        {
            _userBasketService = userBasketService;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<UserBasketGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpGet("{id:int}")]
        [ServiceFilter(typeof(NotFoundFilter<UserBasket, int>))]
        public async Task<IActionResult> GetUserBasketById([FromRoute] int id)
        {
            var response = await _userBasketService.GetUserBasketByIdAsync(id);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<List<UserBasketGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> GetUserBasketByUserId([FromRoute] int id)
        {
            var response = await _userBasketService.GetUserBasketsByUserIdAsync(id);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<List<UserBasketGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> GetUserBasketByFoodId([FromRoute] int id)
        {
            var response = await _userBasketService.GetUserBasketsByFoodIdAsync(id);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomResponse<UserBasketGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> AddUserBasket([FromBody] UserBasketPostDto dto)
        {
            var response = await _userBasketService.AddUserBasketAsync(dto);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpDelete("{id:int}")]
        [ServiceFilter(typeof(NotFoundFilter<UserBasket, int>))]
        public async Task<IActionResult> DeleteUserBasket([FromRoute] int id)
        {
            var response = await _userBasketService.DeleteUserBasketAsync(id);
            return SendResponse(response);
        }
    }
}
