using Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContex;
        private Lazy<ICompanyRepository> _companyRepository;
        private Lazy<IEmployeeRepository> _employeeRepository;
        private Lazy<IEstateRepository> _estateRepository;
        private Lazy<ICountryRepository> _countryRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContex = repositoryContext;

            _companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(repositoryContext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(repositoryContext));
            _estateRepository = new Lazy<IEstateRepository>(() => new EstateRepository(repositoryContext));
            _countryRepository = new Lazy<ICountryRepository>>(() => new CountryRepository(repositoryContext));
        }
        public ICompanyRepository Company =>_companyRepository.Value;

        public IEmployeeRepository Employee => _employeeRepository.Value;

        public IEstateRepository Estate => _estateRepository.Value;

        public ICountryRepository Country => _countryRepository.Value;

        public async Task SaveAsync() => await _repositoryContex.SaveChangesAsync();
    }
}
