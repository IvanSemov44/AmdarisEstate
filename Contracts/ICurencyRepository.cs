
using Entities.Models;

namespace Contracts
{
    public interface ICurencyRepository
    {
        Task<IEnumerable<Curency>> GetCurenciesAsync(bool trackChanges);
        Task<Curency> GetCurencyAsync(Guid curencyId,bool trackChanges);
        void CreateCurency(Curency curency);
        void DeleteCurency(Curency curency);
    }
}
