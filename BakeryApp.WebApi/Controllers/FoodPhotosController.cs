using BakeryApp.Business.Interfaces;
using BakeryApp.Model.DTOs.FoodPhoto.Get;
using BakeryApp.Model.DTOs.FoodPhoto.Post;
using BakeryApp.Model.DTOs.FoodPhoto.Put;
using BakeryApp.Model.Entities;
using BakeryApp.WebApi.Filters;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace BakeryApp.WebApi.Controllers
{
    public class FoodPhotosController : BaseController
    {
        private readonly IFoodPhotoService _foodPhotoService;
        public FoodPhotosController(IFoodPhotoService foodPhotoService)
        {
            _foodPhotoService = foodPhotoService;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<List<FoodPhotoGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetFoodPhotos()
        {
            var response = await _foodPhotoService.GetFoodPhotosAsync();
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<FoodPhotoGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpGet("{id:int}")]
        [ServiceFilter(typeof(NotFoundFilter<FoodPhoto, int>))]
        public async Task<IActionResult> GetFoodPhotoById([FromRoute] int id)
        {
            var response = await _foodPhotoService.GetFoodPhotoByIdAsync(id);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomResponse<FoodPhotoGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> AddFoodPhoto([FromBody] FoodPhotoPostDto foodPhotoPostDto)
        {
            var response = await _foodPhotoService.AddFoodPhotoAsync(foodPhotoPostDto);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateFoodPhoto([FromBody] FoodPhotoPutDto foodPhotoPutDto)
        {
            var response = await _foodPhotoService.UpdateFoodPhotoAsync(foodPhotoPutDto);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpDelete("{id:int}")]
        [ServiceFilter(typeof(NotFoundFilter<FoodPhoto, int>))]
        public async Task<IActionResult> DeleteFoodPhoto([FromRoute] int id)
        {
            var response = await _foodPhotoService.DeleteFoodPhotoAsync(id);
            return SendResponse(response);
        }
    }
}
