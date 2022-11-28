namespace Contracts
{
    using System.Threading.Tasks;

    public interface IRepositoryManager
    {
        ICompanyRepository Company { get;}
        IEmployeeRepository Employee { get;}

        IEstateRepository Estate { get; }
        ICityRepository City { get;}
        ICountryRepository Country { get;}
        ICurencyRepository Curency { get; }
        IEstateTypeRepository EstateType { get; }
        IImageRepository Image { get; }

        Task SaveAsync();
    }
}
