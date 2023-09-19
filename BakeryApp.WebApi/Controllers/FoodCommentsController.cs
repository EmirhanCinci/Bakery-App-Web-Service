using BakeryApp.Business.Interfaces;
using BakeryApp.Model.DTOs.FoodComment.Get;
using BakeryApp.Model.DTOs.FoodComment.Post;
using BakeryApp.Model.DTOs.FoodComment.Put;
using BakeryApp.Model.Entities;
using BakeryApp.WebApi.Filters;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace BakeryApp.WebApi.Controllers
{
    public class FoodCommentsController : BaseController
    {
        private readonly IFoodCommentService _foodCommentService;
        public FoodCommentsController(IFoodCommentService foodCommentService)
        {
            _foodCommentService = foodCommentService;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<List<FoodCommentGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetFoodComments()
        {
            var response = await _foodCommentService.GetFoodCommentsAsync();
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<FoodCommentGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpGet("{id:int}")]
        [ServiceFilter(typeof(NotFoundFilter<FoodComment, int>))]
        public async Task<IActionResult> GetFoodCommentById([FromRoute] int id)
        {
            var response = await _foodCommentService.GetFoodCommentByIdAsync(id);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomResponse<FoodCommentGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> AddFoodComment([FromBody] FoodCommentPostDto dto)
        {
            var response = await _foodCommentService.AddFoodCommentAsync(dto);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateFoodComment([FromBody] FoodCommentPutDto dto)
        {
            var response = await _foodCommentService.UpdateFoodCommentAsync(dto);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpDelete("{id:int}")]
        [ServiceFilter(typeof(NotFoundFilter<FoodComment, int>))]
        public async Task<IActionResult> DeleteFoodComment([FromRoute] int id)
        {
            var response = await _foodCommentService.DeleteFoodCommentAsync(id);
            return SendResponse(response);
        }
    }
}
