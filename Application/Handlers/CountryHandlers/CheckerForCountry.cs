namespace IvanRealEstate.Application.Handlers.CountryHandlers
{
    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Entities.Exceptions.NotFound;

    public static class CheckerForCountry
    {
       public async static Task<Country> CheckIfCountryExistAndReturnIt(IRepositoryManager repositoryManager,Guid countryId,bool trackChanges)
        {
            var country = await repositoryManager.Country.GetCountryAsync(countryId, trackChanges);
            if (country is null)
                throw new CountryNotFoundException(countryId);

            return country;
        }
    }
}
