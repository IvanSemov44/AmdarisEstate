namespace IvanRealEstate.Application.Handlers.OwnerImageHandlers
{
    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Entities.Exceptions.NotFound;

    public static class CheckerForOwnerImage
    {
        public async static Task<OwnerImage> CheckIfOwnerImageExistAndReturnIt(IRepositoryManager repositoryManager, Guid ownerId, Guid ownerImageId, bool trackChanges)
        {
            var image = await repositoryManager.OwnerImage.GetOwnerImageAsync(ownerId, ownerImageId, trackChanges);
            if (image is null)
                throw new ImageNotFoundException(ownerImageId);

            return image;
        }

    }
}
