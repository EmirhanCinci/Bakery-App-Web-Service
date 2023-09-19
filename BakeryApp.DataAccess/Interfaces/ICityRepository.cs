using BakeryApp.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace BakeryApp.DataAccess.Interfaces
{
    public interface ICityRepository : IBaseRepository<City, int>
    {
        Task<City?> GetSingleCityByIdWithUsersAsync(int cityId, params string[] includeList);
    }
}
