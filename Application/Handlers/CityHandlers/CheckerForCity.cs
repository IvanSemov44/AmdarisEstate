namespace IvanRealEstate.Application.Handlers.CityHandlers
{
    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Entities.Exceptions;

    public static class CheckerForCity
    {
        public async static Task<City> CheckIfCityExistAndReturnIt(IRepositoryManager _repositoryManager,Guid cityId,bool trackChanges)
        {
            var city = await _repositoryManager.City.GetCityAsync(cityId, trackChanges);
            if (city is null)
                throw new CityNotFoundException(cityId);

            return city;
        }
    }
}
