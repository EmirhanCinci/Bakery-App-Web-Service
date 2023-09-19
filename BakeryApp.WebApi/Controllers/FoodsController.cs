using BakeryApp.Business.Interfaces;
using BakeryApp.Model.DTOs.Food.Get;
using BakeryApp.Model.DTOs.Food.Post;
using BakeryApp.Model.DTOs.Food.Put;
using BakeryApp.Model.Entities;
using BakeryApp.WebApi.Filters;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace BakeryApp.WebApi.Controllers
{
    public class FoodsController : BaseController
    {
        private readonly IFoodService _foodService;
        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<List<FoodGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetFoods()
        {
            var response = await _foodService.GetFoodsAsync();
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<FoodGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpGet("{id:int}")]
        [ServiceFilter(typeof(NotFoundFilter<Food, int>))]
        public async Task<IActionResult> GetFoodById([FromRoute] int id)
        {
            var response = await _foodService.GetFoodByIdAsync(id);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomResponse<FoodGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> AddFood([FromBody] FoodPostDto dto)
        {
            var response = await _foodService.AddFoodAsync(dto);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateCity([FromBody] FoodPutDto dto)
        {
            var response = await _foodService.UpdateFoodAsync(dto);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpDelete("{id:int}")]
        [ServiceFilter(typeof(NotFoundFilter<Food, int>))]
        public async Task<IActionResult> DeleteCity([FromRoute] int id)
        {
            var response = await _foodService.DeleteFoodAsync(id);
            return SendResponse(response);
        }
    }
}
