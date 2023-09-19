using BakeryApp.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace BakeryApp.DataAccess.Interfaces
{
    public interface ICountryRepository : IBaseRepository<Country, int>
    {
        Task<Country?> GetSingleCountryByIdWithCitiesAsync(int countryId, params string[] includeList);
    }
}
