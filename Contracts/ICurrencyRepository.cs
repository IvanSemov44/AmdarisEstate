namespace IvanRealEstate.Contracts
{
    using IvanRealEstate.Entities.Models;

    public interface ICurrencyRepository
    {
        Task<IEnumerable<Currency?>> GetCurrenciesAsync(bool trackChanges);
        Task<Currency?> GetCurrencyAsync(Guid currencyId,bool trackChanges);
        void CreateCurrency(Currency currency);
        void DeleteCurrency(Currency currency);
    }
}
