using BakeryApp.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace BakeryApp.DataAccess.Interfaces
{
    public interface IGenderRepository : IBaseRepository<Gender, int>
    {
        Task<Gender?> GetSingleGenderByIdWithUsersAsync(int genderId, params string[] includeList);
    }
}
