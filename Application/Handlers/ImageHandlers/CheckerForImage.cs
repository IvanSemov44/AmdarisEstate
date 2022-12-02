namespace IvanRealEstate.Application.Handlers.ImageHandlers
{
    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Entities.Exceptions;

    public static class CheckerForImage
    {
        public async static Task<Image> CheckIfImageExistAndReturnIt(IRepositoryManager repositoryManager,Guid estateId ,Guid imageId, bool trackChanges)
        {
            var image = await repositoryManager.Image.GetImageAsync(estateId,imageId, trackChanges);
            if (image is null)
                throw new EstateNotFoundException(imageId);

            return image;
        }

    }
}
