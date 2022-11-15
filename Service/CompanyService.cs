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

        public async Task<IEnumerable<CompanyDto>> GetAllCompanyAsync(bool trackChanges)
        {
            var companies = await _repositoryManager.Company.GetAllCompaniesAsync(trackChanges);

            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

            return companiesDto;
        }

        public async Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();

            var companyEntites = await _repositoryManager.Company.GetByIdsAsync(ids, trackChanges);

            if (ids.Count() != companyEntites.Count())
                throw new CollectionByIdsBadRequestException();

            var companiesForReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntites);

            return companiesForReturn;
        }

        public async Task<CompanyDto> GetCompanyAsync(Guid id, bool trackChanges)
        {
            var company = await GetCompanyAndCheckIfItExists(id, trackChanges);

            var companyDto = _mapper.Map<CompanyDto>(company);

            return companyDto;
        }

        public async Task<(IEnumerable<CompanyDto> companies, string ids)> 
            CreateCompanyCollectionAsync
            (IEnumerable<CompanyForCreationDto> companyCollection)
        {
            if (companyCollection is null)
                throw new CompanyCollectionBadRequest();

            var companyEntities = _mapper.Map<IEnumerable<Company>>(companyCollection);
            foreach (var company in companyEntities)
            {
                _repositoryManager.Company.CreateCompany(company);
            }

            await _repositoryManager.SaveAsync();

            var companyCollectionForReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
            var ids = string.Join(",", companyCollectionForReturn.Select(c => c.Id));

            return (companies: companyCollectionForReturn, ids: ids);
        }

        public async Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company)
        {
            var companyEntity = _mapper.Map<Company>(company);

            _repositoryManager.Company.CreateCompany(companyEntity);
            await _repositoryManager.SaveAsync();

            var companyForReturn = _mapper.Map<CompanyDto>(companyEntity);

            return companyForReturn;
        }

        public async Task UpdateCompanyAsync(Guid id, CompanyForUpdateDto companyForUpdateDto, bool trackChanges)
        {
            var company = await GetCompanyAndCheckIfItExists(id, trackChanges);

            _mapper.Map(companyForUpdateDto, company);
            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteCompanyAsync(Guid id, bool trackChanges)
        {
            var company = await GetCompanyAndCheckIfItExists(id, trackChanges);

            _repositoryManager.Company.DeleteCompany(company);
            await _repositoryManager.SaveAsync();
        }

        private async Task<Company> GetCompanyAndCheckIfItExists(Guid id, bool trackChanges)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(id, trackChanges: false);
           
            if (company is null)
                throw new CompanyNotFoundException(id);

            return company;
        }
    }
}
