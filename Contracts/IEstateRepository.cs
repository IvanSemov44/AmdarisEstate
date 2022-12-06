namespace IvanRealEstate.Contracts
{
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Shared.RequestFeatures;

    public interface IEstateRepository
    {
        Task<IEnumerable<Estate>> GetAllEstatesAsync(bool trackChanges);
        Task<PagedList<Estate>> GetEstatesForPageAsync(EstateParameters estateParameters,bool trackChanges);
        Task<Estate?> GetEstateAsync(Guid estateId,bool trackChanges);
        void CreateEstate(Estate estate);
        void DeleteEstate(Estate estate);
    }
}
