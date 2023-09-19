using BakeryApp.Business.Interfaces;
using BakeryApp.Model.DTOs.Gender.Get;
using BakeryApp.Model.Entities;
using BakeryApp.WebApi.Filters;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace BakeryApp.WebApi.Controllers
{
    public class GendersController : BaseController
    {
        private readonly IGenderService _genderService;
        public GendersController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<List<GenderGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetGenders()
        {
            var response = await _genderService.GetGendersAsync();
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<GenderGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CustomResponse<NoData>))]
        #endregion
        [HttpGet("{id:int}")]
        [ServiceFilter(typeof(NotFoundFilter<Gender, int>))]
        public async Task<IActionResult> GetGenderById([FromRoute] int id)
        {
            var response = await _genderService.GetGenderByIdAsync(id);
            return SendResponse(response);
        }
    }
}
