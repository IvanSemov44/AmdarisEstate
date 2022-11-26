using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCity(City city) => Create(city);

        public void DeleteCity(City city) => Delete(city);

        public async Task<IEnumerable<City>> GetCitiesAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(c => c.CityName).ToListAsync();

        public async Task<City> GetCityAsync(Guid cityId,bool trackChanges) =>
            await FindByCondition(c => c.CityId.Equals(cityId),trackChanges).SingleOrDefaultAsync();
    }
}
