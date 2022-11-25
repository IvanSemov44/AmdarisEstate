using Entities.Models;

namespace Contracts
{
    public interface IEstateRepository
    {
        Task<IEnumerable<Estate>> GetAllEstatesAsync(bool trackChanges);
        Task<Estate> GetEstateAsync(Guid estateId,bool trackChanges);
        void CreateEstate(Estate estate,Guid countryId,Guid cityId,Guid curencyId,Guid estateTypeId);
        void DeleteEstate(Estate estate);
    }
}
