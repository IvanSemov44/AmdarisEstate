namespace IvanRealEstate.Repository
{

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;

    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCity(City city) => Create(city);

        public void DeleteCity(City city) => Delete(city);

        public async Task<IEnumerable<City?>> GetCitiesAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(c => c.CityName).ToListAsync();

        public async Task<City?> GetCityAsync(Guid cityId, bool trackChanges) =>
            await FindByCondition(c => c.CityId.Equals(cityId), trackChanges).SingleOrDefaultAsync();
    }
}
