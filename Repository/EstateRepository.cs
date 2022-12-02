namespace IvanRealEstate.Repository
{
    using Microsoft.EntityFrameworkCore;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;

    public class EstateRepository : RepositoryBase<Estate>, IEstateRepository
    {
        public EstateRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Estate>> GetAllEstatesAsync(bool trackChanges) =>
            await FindAll(trackChanges).Include(b=>b.Images)
            .OrderBy(e => e.YearOfCreation)
            .ToListAsync();

        public async Task<Estate?> GetEstateAsync(Guid estateId, bool trackChanges) =>
            await FindByCondition(e => e.EstateId.Equals(estateId), trackChanges).Include(b=>b.Images).SingleOrDefaultAsync();

        public void CreateEstate(Estate estate) => Create(estate);

        public void DeleteEstate(Estate estate) => Delete(estate);

    }
}
