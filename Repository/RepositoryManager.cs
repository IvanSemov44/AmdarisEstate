namespace IvanRealEstate.Repository
{
    using Contracts;

    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContex;

        private Lazy<ICompanyRepository> _companyRepository;
        private Lazy<IEmployeeRepository> _employeeRepository;

        private Lazy<IEstateRepository> _estateRepository;
        private Lazy<ICountryRepository> _countryRepository;
        private Lazy<ICityRepository> _cityRepository;
        private Lazy<ICurrencyRepository> _currencyRepository;
        private Lazy<IEstateTypeRepository> _estateTypeRepository;
        private Lazy<IImageRepository> _imageRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContex = repositoryContext;

            _companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(repositoryContext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(repositoryContext));
           
            _estateRepository = new Lazy<IEstateRepository>(() => new EstateRepository(repositoryContext));
            _countryRepository = new Lazy<ICountryRepository>(() => new CountryRepository(repositoryContext));
            _cityRepository = new Lazy<ICityRepository> (() => new CityRepository(repositoryContext));
            _currencyRepository = new Lazy<ICurrencyRepository>(() => new CurrencyRepository(repositoryContext));
            _estateTypeRepository = new Lazy<IEstateTypeRepository>(() => new EstateTypeRepository(repositoryContext));
            _imageRepository = new Lazy<IImageRepository> (()=>new ImageRepository(repositoryContext));
        }
        
        public ICompanyRepository Company => _companyRepository.Value;

        public IEmployeeRepository Employee => _employeeRepository.Value;

        public IEstateRepository Estate => _estateRepository.Value;

        public ICountryRepository Country => _countryRepository.Value;

        public ICityRepository City => _cityRepository.Value;

        public ICurrencyRepository Currency => _currencyRepository.Value;

        public IEstateTypeRepository EstateType => _estateTypeRepository.Value;

        public IImageRepository Image => _imageRepository.Value;

        public async Task SaveAsync() => await _repositoryContex.SaveChangesAsync();
    }
}
