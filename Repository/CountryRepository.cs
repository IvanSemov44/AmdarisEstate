using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCountry(Country country) => Create(country);

        public void DeleteCountry(Country country) => Delete(country);

        public async Task<IEnumerable<Country>> GetCountries(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.CountryName)
            .ToListAsync();

        public async Task<Country> GetCountry(Guid id, bool trackChanges) =>
            await FindByCondition(c => c.CountryId.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }
}
