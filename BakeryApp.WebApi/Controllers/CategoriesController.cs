using BakeryApp.Business.Interfaces;
using BakeryApp.Model.DTOs.Category.Get;
using BakeryApp.Model.DTOs.Category.Post;
using BakeryApp.Model.DTOs.Category.Put;
using BakeryApp.Model.Entities;
using BakeryApp.WebApi.Filters;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace BakeryApp.WebApi.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<List<CategoryGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var response = await _categoryService.GetAllCategoriesAsync();
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<CategoryGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpGet("{id:int}")]
        [ServiceFilter(typeof(NotFoundFilter<Category, int>))]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            var response = await _categoryService.GetCategoryByIdAsync(id);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomResponse<CategoryGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryPostDto dto)
        {
            var response = await _categoryService.AddCategoryAsync(dto);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryPutDto dto)
        {
            var response = await _categoryService.UpdateCategoryAsync(dto);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpDelete("{id:int}")]
        [ServiceFilter(typeof(NotFoundFilter<Category, int>))]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var response = await _categoryService.DeleteCategoryAsync(id);
            return SendResponse(response);
        }
    }
}
