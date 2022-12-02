namespace IvanRealEstate.Contracts
{
    using IvanRealEstate.Entities.Models;

    public interface IEstateTypeRepository
    {
        Task<IEnumerable<EstateType>> GetEstateTypesAsync(bool trackChanges);
        Task<EstateType?> GetEstateTypeAsync(Guid estateTypeId, bool trackChanges);
        void CreateEstateType(EstateType estateType);
        void DeleteEstateType(EstateType estateType);
    }
}
