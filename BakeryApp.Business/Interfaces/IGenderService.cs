using BakeryApp.Model.DTOs.Gender.Get;
using BakeryApp.Model.Entities;
using Infrastructure.Business.Interfaces;
using Infrastructure.Utilities.ApiResponses;

namespace BakeryApp.Business.Interfaces
{
    public interface IGenderService : IBaseService<Gender, int>
    {
        Task<CustomResponse<List<GenderGetDto>>> GetGendersAsync();
        Task<CustomResponse<GenderGetDto>> GetGenderByIdAsync(int id);
    }
}
