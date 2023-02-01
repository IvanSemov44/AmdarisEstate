namespace IvanRealEstate.Application.Handlers.CompanyImageHandlers
{
    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Entities.Exceptions.NotFound;

    public class CheckerForCompanyImage
    {
        public async static Task<Image> CheckIfCompanyImageExistAndReturnIt(IRepositoryManager repositoryManager, Guid companyId, Guid companyImageId, bool trackChanges)
        {
            var image = await repositoryManager.CompanyImage.GetCompanyImageAsync(companyId, companyImageId, trackChanges);
            if (image is null)
                throw new ImageNotFoundException(companyImageId);

            return image;
        }
    }
}
