using Entities.Models;

namespace Contracts
{
    public interface IImageRepository
    {
        Task<IEnumerable<Image>> GetImagesAsync(Guid estateId,bool trackChanges);
        Task<Image> GetImageAsync(Guid estateId, Guid imageId, bool trackChanges);
        void CreateImage(Guid estateId,Image image);
        void DeleteImage(Image image); 
    }
}
