using BakeryApp.Business.Interfaces;
using BakeryApp.Model.DTOs.FoodMaterial.Get;
using BakeryApp.Model.DTOs.FoodMaterial.Post;
using BakeryApp.Model.DTOs.FoodMaterial.Put;
using BakeryApp.Model.Entities;
using BakeryApp.WebApi.Filters;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace BakeryApp.WebApi.Controllers
{
    public class FoodMaterialsController : BaseController
    {
        private readonly IFoodMaterialService _foodMaterialService;
        public FoodMaterialsController(IFoodMaterialService foodMaterialService)
        {
            _foodMaterialService = foodMaterialService;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<List<FoodMaterialGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetFoodMaterials()
        {
            var response = await _foodMaterialService.GetFoodMaterialsAsync();
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<FoodMaterialGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpGet("{id:int}")]
        [ServiceFilter(typeof(NotFoundFilter<FoodMaterial, int>))]
        public async Task<IActionResult> GetFoodMaterial([FromRoute] int id)
        {
            var response = await _foodMaterialService.GetFoodMaterialByIdAsync(id);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomResponse<FoodMaterialGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> AddFoodMaterial([FromBody] FoodMaterialPostDto foodMaterialPostDto)
        {
            var response = await _foodMaterialService.AddFoodMaterialAsync(foodMaterialPostDto);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateFoodMaterial([FromBody] FoodMaterialPutDto foodMaterialPutDto)
        {
            var response = await _foodMaterialService.UpdateFoodMaterialAsync(foodMaterialPutDto);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpDelete("{id:int}")]
        [ServiceFilter(typeof(NotFoundFilter<FoodMaterial, int>))]
        public async Task<IActionResult> DeleteFoodMaterial([FromRoute] int id)
        {
            var response = await _foodMaterialService.DeleteFoodMaterialAsync(id);
            return SendResponse(response);
        }
    }
}
