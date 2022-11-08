using Entitities.Models;

namespace Service.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAllCompany(bool trackChanges);
    }
}
