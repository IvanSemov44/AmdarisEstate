namespace IvanRealEstate.Contracts
{
    using IvanRealEstate.Entities.Models;

    public interface IEstateRepository
    {
        Task<IEnumerable<Estate>> GetAllEstatesAsync(bool trackChanges);
        Task<Estate?> GetEstateAsync(Guid estateId,bool trackChanges);
        void CreateEstate(Estate estate);
        void DeleteEstate(Estate estate);
    }
}
