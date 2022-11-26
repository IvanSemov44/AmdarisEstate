
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CurencyRepository : RepositoryBase<Curency>, ICurencyRepository
    {
        public CurencyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCurency(Curency curency) => Create(curency);

        public void DeleteCurency(Curency curency) => Delete(curency);

        public async Task<IEnumerable<Curency>> GetCurenciesAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(c => c.CurencyName).ToListAsync();

        public async Task<Curency> GetCurencyAsync(Guid curencyId, bool trackChanges) =>
            await FindByCondition(c => c.CurencyId.Equals(curencyId), trackChanges).SingleOrDefaultAsync();

        public async Task<Curency> GetCurencyByNameAsync(string curencyName, bool trackChanges) =>
                await FindByCondition(c => c.CurencyName.Equals(curencyName), trackChanges).SingleOrDefaultAsync();
    }
}
