namespace IvanRealEstate.Application.Handlers.CurrencyHandlers
{
    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Entities.Exceptions.NotFound;

    public static class CheckerForCurrency
    {
        public async static Task<Currency> CheckIfCurrencyExistAndReturnIt(IRepositoryManager repositoryManager, Guid currencyId, bool trackChanges)
        {
            var currency = await repositoryManager.Currency.GetCurrencyAsync(currencyId, trackChanges);
            if (currency is null)
                throw new CurrencyNotFoundException(currencyId);

            return currency;
        }

    }
}
