namespace IvanRealEstate.Contracts
{
    using System.Threading.Tasks;

    public interface IRepositoryManager
    {
        ICompanyRepository Company { get;}
        IEstateRepository Estate { get; }
        ICityRepository City { get;}
        ICountryRepository Country { get;}
        ICurrencyRepository Currency { get; }
        IEstateTypeRepository EstateType { get; }
        IImageRepository Image { get; }
        IMessageRepository Message { get; }
        IOwnerImageRepository OwnerImage { get; }
        ICompanyImageRepository CompanyImage { get; }
        Task SaveAsync();
    }
}
