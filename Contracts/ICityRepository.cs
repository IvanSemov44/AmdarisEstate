namespace IvanRealEstate.Contracts
{
    using Entities.Models;

    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync(bool trackChanges);
        Task<City> GetCityAsync(Guid cityId,bool trackChanges);
        Task<City> GetCityByNameAsync(string cityName, bool trackChanges);
        void CreateCity(City city);
        void DeleteCity(City city);
    }
}
