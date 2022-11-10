using Shared.DataTransferObject;

namespace Service.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetAllCompany(bool trackChanges);

        IEnumerable<CompanyDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);

        CompanyDto GetCompany(Guid Id, bool trackChanges);

        CompanyDto CreateCompany(CompanyForCreationDto company);

        void DeleteCompany(Guid companyId, bool trackChanges);

        (IEnumerable<CompanyDto> companies, string ids) 
            CreateCompanyCollection(IEnumerable<CompanyForCreationDto> companyCollection);
    }
}
