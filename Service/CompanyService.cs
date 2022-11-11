using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObject;

namespace Service
{
    internal sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public CompanyService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public IEnumerable<CompanyDto> GetAllCompany(bool trackChanges)
        {
            var companies = _repositoryManager.Company.GetAllCompanies(trackChanges);

            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

            return companiesDto;
        }

        public IEnumerable<CompanyDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();

            var companyEntites = _repositoryManager.Company.GetByIds(ids, trackChanges);

            if (ids.Count() != companyEntites.Count())
                throw new CollectionByIdsBadRequestException();

            var companiesForReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntites);

            return companiesForReturn;
        }

        public CompanyDto GetCompany(Guid id, bool trackChanges)
        {
            var company = _repositoryManager.Company.GetCompany(id, trackChanges);

            if (company is null)
                throw new CompanyNotFoundException(id);

            var companyDto = _mapper.Map<CompanyDto>(company);

            return companyDto;
        }

        public CompanyDto CreateCompany(CompanyForCreationDto company)
        {
            var companyEntity = _mapper.Map<Company>(company);

            _repositoryManager.Company.CreateCompany(companyEntity);
            _repositoryManager.Save();

            var companyForReturn = _mapper.Map<CompanyDto>(companyEntity);

            return companyForReturn;
        }

        public void UpdateCompany(Guid id,CompanyForUpdateDto companyForUpdateDto,bool trackChanges)
        {
            var company =_repositoryManager.Company.GetCompany(id, trackChanges);

            if (company is null)
                throw new CompanyNotFoundException(id);

            _mapper.Map(companyForUpdateDto,company);
            _repositoryManager.Save();
        }

        public void DeleteCompany(Guid id, bool trackChanges)
        {
            var company = _repositoryManager.Company.GetCompany(id, trackChanges: false);
            if (company is null)
                throw new CompanyNotFoundException(id);

            _repositoryManager.Company.DeleteCompany(company);
            _repositoryManager.Save();
        }
        public(IEnumerable<CompanyDto> companies, string ids) CreateCompanyCollection
            (IEnumerable<CompanyForCreationDto> companyCollection)
        {
            if (companyCollection is null)
                throw new CompanyCollectionBadRequest();

            var companyEntities = _mapper.Map<IEnumerable<Company>>(companyCollection);
            foreach (var company in companyEntities)
            {
                _repositoryManager.Company.CreateCompany(company);
            }

            _repositoryManager.Save();

            var companyCollectionForReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
            var ids = string.Join(",", companyCollectionForReturn.Select(c => c.Id));

            return (companies: companyCollectionForReturn, ids: ids);
        }
    }
}
