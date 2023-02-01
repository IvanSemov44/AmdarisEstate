namespace IvanRealEstate.Contracts
{
    using IvanRealEstate.Entities.Models;

    public interface ICompanyImageRepository
    {
        Task<IEnumerable<Image>> GetCompanyImagesAsync(Guid companyId, bool trackChanges);
        Task<Image?> GetCompanyImageAsync(Guid companyId, Guid imageId, bool trackChanges);
        void CreateCompanyImage(Guid companyId, Image image);
        void DeleteCompanyImage(Image companyId);
    }
}
    