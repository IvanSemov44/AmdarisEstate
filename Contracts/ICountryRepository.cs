using Entities.Models;

namespace Contracts
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetCountries(bool trackChanges);
        Task<Country> GetCountry(Guid id, bool trackChanges);
        void CreateCountry(Country country);
        void DeleteCountry(Country country);
    }
}
