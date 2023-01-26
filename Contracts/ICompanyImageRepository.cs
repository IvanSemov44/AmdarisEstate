namespace IvanRealEstate.Contracts
{
    using IvanRealEstate.Entities.Models;

    public interface ICompanyImageRepository
    {
        Task<IEnumerable<CompanyImage>> GetCompanyImagesAsync(Guid companyId, bool trackChanges);
        Task<CompanyImage?> GetCompanyImageAsync(Guid companyId, Guid imageId, bool trackChanges);
        void CreateCompanyImage(Guid companyId, CompanyImage image);
        void DeleteCompanyImage(CompanyImage companyId);
    }
}
    