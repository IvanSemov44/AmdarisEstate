namespace IvanRealEstate.Repository
{
    using Microsoft.EntityFrameworkCore;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;

    public class CurrencyRepository : RepositoryBase<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCurrency(Currency currency) => Create(currency);

        public void DeleteCurrency(Currency currency) => Delete(currency);

        public async Task<IEnumerable<Currency?>> GetCurrenciesAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(c => c.CurrencyName).ToListAsync();

        public async Task<Currency?> GetCurrencyAsync(Guid currencyId, bool trackChanges) =>
            await FindByCondition(c => c.CurrencyId.Equals(currencyId), trackChanges).SingleOrDefaultAsync();
      }
}
