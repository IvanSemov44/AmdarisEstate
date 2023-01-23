namespace IvanRealEstate.Application.Handlers.EstateHandlers
{
    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Entities.Exceptions.NotFound;

    public static class CheckerForEstate
    {
        public async static Task<Estate> CheckIfEstateExistAndReturnIt(IRepositoryManager repositoryManager, Guid estateId, bool trackChanges)
        {
            var estate = await repositoryManager.Estate.GetEstateAsync(estateId, trackChanges);
            if (estate is null)
                throw new EstateNotFoundException(estateId);

            return estate;
        }

    }
}
