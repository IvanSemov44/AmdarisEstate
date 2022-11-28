namespace IvanRealEstate.Contracts
{
    using Entities.Models;

    public interface ICurencyRepository
    {
        Task<IEnumerable<Curency>> GetCurenciesAsync(bool trackChanges);
        Task<Curency> GetCurencyAsync(Guid curencyId,bool trackChanges);
        Task<Curency> GetCurencyByNameAsync(string curencyName, bool trackChanges);
        void CreateCurency(Curency curency);
        void DeleteCurency(Curency curency);
    }
}
