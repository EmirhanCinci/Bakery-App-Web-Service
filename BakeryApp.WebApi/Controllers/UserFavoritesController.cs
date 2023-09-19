using BakeryApp.Business.Interfaces;
using BakeryApp.Model.DTOs.UserFavorite.Get;
using BakeryApp.Model.DTOs.UserFavorite.Post;
using BakeryApp.Model.Entities;
using BakeryApp.WebApi.Filters;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace BakeryApp.WebApi.Controllers
{
    public class UserFavoritesController : BaseController
    {
        private readonly IUserFavoriteService _userFavoriteService;
        public UserFavoritesController(IUserFavoriteService userFavoriteService)
        {
            _userFavoriteService = userFavoriteService;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<UserFavoriteGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpGet("{id:int}")]
        [ServiceFilter(typeof(NotFoundFilter<UserFavorite, int>))]
        public async Task<IActionResult> GetUserFavoriteById([FromRoute] int id)
        {
            var response = await _userFavoriteService.GetUserFavoriteByIdAsync(id);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<List<UserFavoriteGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> GetUserFavoriteByUserId([FromRoute] int id)
        {
            var response = await _userFavoriteService.GetUserFavoritesByUserIdAsync(id);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<List<UserFavoriteGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> GetUserFavoriteByFoodId([FromRoute] int id)
        {
            var response = await _userFavoriteService.GetUserFavoritesByFoodIdAsync(id);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomResponse<UserFavoriteGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> AddUserFavorite([FromBody] UserFavoritePostDto dto)
        {
            var response = await _userFavoriteService.AddUserFavoriteAsync(dto);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpDelete("{id:int}")]
        [ServiceFilter(typeof(NotFoundFilter<UserFavorite, int>))]
        public async Task<IActionResult> DeleteUserFavorite([FromRoute] int id)
        {
            var response = await _userFavoriteService.DeleteUserFavoriteAsync(id);
            return SendResponse(response);
        }
    }
}
