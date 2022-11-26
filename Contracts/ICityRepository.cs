
using Entities.Models;

namespace Contracts
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync(bool trackChanges);
        Task<City> GetCityAsync(Guid cityId,bool trackChanges);
        void CreateCity(City city);
        void DeleteCity(City city);
    }
}
