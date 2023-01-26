namespace IvanRealEstate.Contracts
{
    using IvanRealEstate.Entities.Models;

    public interface IOwnerImageRepository
    {
        Task<IEnumerable<OwnerImage>> GetOwnerImagesAsync(Guid ownerId, bool trackChanges);
        Task<OwnerImage?> GetOwnerImageAsync(Guid ownerId, Guid imageId, bool trackChanges);
        void CreateOwnerImage(Guid ownerId, OwnerImage image);
        void DeleteOwnerImage(OwnerImage image);
    }
}
