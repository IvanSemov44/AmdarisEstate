namespace Repository
{
    using Contracts;
    using Entities.Models;
    using Microsoft.EntityFrameworkCore;
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCountry(Country country) => Create(country);

        public void DeleteCountry(Country country) => Delete(country);

        public async Task<IEnumerable<Country>> GetCountriesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.CountryName)
            .ToListAsync();

        public async Task<Country> GetCountryAsync(Guid id, bool trackChanges) =>
            await FindByCondition(c => c.CountryId.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<Country> GetCountryByNameAsync(string countryName, bool trackChanges) =>
            await FindByCondition(c => c.CountryName.Equals(countryName), trackChanges).SingleOrDefaultAsync();
    }
}
