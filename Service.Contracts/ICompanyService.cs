using Shared.DataTransferObject;

namespace Service.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetAllCompany(bool trackChanges);

        CompanyDto GetCompany(Guid Id,bool trackChanges);
    }
}
