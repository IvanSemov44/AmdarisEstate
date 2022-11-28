namespace Repository
{
    using Contracts;
    using Entities.Models;
    using Microsoft.EntityFrameworkCore;
    public class ImageRepository : RepositoryBase<Image>, IImageRepository
    {
        public ImageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateImage(Guid estateId, Image image)
        {
            image.EstateId = estateId;
            Create(image);
        }

        public void DeleteImage(Image image) => Delete(image);

        public async Task<Image> GetImageAsync(Guid estateId, Guid imageId, bool trackChanges) =>
            await FindByCondition(i => i.EstateId.Equals(estateId) && i.ImageId.Equals(imageId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Image>> GetImagesAsync(Guid estateId, bool trackChanges) =>
        await FindByCondition(i=>i.EstateId.Equals(estateId),trackChanges).ToListAsync();
    }
}
