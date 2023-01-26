namespace IvanRealEstate.Repository
{
    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using Microsoft.EntityFrameworkCore;

    internal class OwnerImageRepository : RepositoryBase<OwnerImage>, IOwnerImageRepository
    {
        public OwnerImageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateOwnerImage(Guid ownerId, OwnerImage image)
        {
            image.OwnerId = ownerId;
            Create(image);
        }

        public void DeleteOwnerImage(OwnerImage image) => Delete(image);

        public async Task<OwnerImage?> GetOwnerImageAsync(Guid ownerId, Guid imageId, bool trackChanges) =>
            await FindByCondition(i => i.OwnerId.Equals(ownerId) && i.OwnerImageId.Equals(imageId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<OwnerImage>> GetOwnerImagesAsync(Guid ownerId, bool trackChanges) =>
        await FindByCondition(i => i.OwnerId.Equals(ownerId), trackChanges).ToListAsync();
    }
}
