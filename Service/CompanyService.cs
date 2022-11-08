using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.DataTransferObject;

namespace Service
{
    internal sealed class CompanyService :ICompanyService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public CompanyService(IRepositoryManager repositoryManager, ILoggerManager loggerManager,IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public IEnumerable<CompanyDto> GetAllCompany(bool trackChanges)
        {
            try
            {
                var companies =  _repositoryManager.Company.GetAllCompanies(trackChanges);

                var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

                return companiesDto;
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Someting went wrong in the {nameof(GetAllCompany)} service method {ex}");
                throw;
            }
        }
    }
}
