using Contracts;
using Entitities.Models;
using Service.Contracts;

namespace Service
{
    internal sealed class CompanyService :ICompanyService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public CompanyService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }

        public IEnumerable<Company> GetAllCompany(bool trackChanges)
        {
            try
            {
                return _repositoryManager.Company.GetAllCompanies(trackChanges);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Someting went wrong in the {nameof(GetAllCompany)} service method {ex}");
                throw;
            }
        }
    }
}
