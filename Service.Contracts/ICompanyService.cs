using Shared.DataTransferObject;

namespace Service.Contracts
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllCompanyAsync(bool trackChanges);

        Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);

        Task<CompanyDto> GetCompanyAsync(Guid Id, bool trackChanges);

        Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company);

        Task UpdateCompanyAsync(Guid Id, CompanyForUpdateDto companyForUpdate, bool trackChanges);
        Task DeleteCompanyAsync(Guid companyId, bool trackChanges);

        Task<(IEnumerable<CompanyDto> companies, string ids)>
            CreateCompanyCollectionAsync
            (IEnumerable<CompanyForCreationDto> companyCollection);


    }
}
