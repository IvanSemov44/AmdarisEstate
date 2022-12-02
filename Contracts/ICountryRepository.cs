namespace IvanRealEstate.Contracts
{
    using IvanRealEstate.Entities.Models;

    public interface ICountryRepository
    {
        Task<IEnumerable<Country?>> GetCountriesAsync(bool trackChanges);
        Task<Country?> GetCountryAsync(Guid id, bool trackChanges);
        void CreateCountry(Country country);
        void DeleteCountry(Country country);
    }
}
