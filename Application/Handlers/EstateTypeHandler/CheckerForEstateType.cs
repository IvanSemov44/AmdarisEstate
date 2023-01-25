namespace IvanRealEstate.Application.Handlers.EstateTypeHandler
{
    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Entities.Exceptions.NotFound;

    public static class CheckerForEstateType
    {
        public async static Task<EstateType> CheckIfEstateTypeExistAndReturnIt(IRepositoryManager repositoryManager, Guid estateTypeId, bool trackChanges)
        {
            var estateTypeEntity = await repositoryManager.EstateType.GetEstateTypeAsync(estateTypeId, trackChanges);
            if (estateTypeEntity is null)
                throw new EstateTypeNotFoundException(estateTypeId);

            return estateTypeEntity;
        }

    }
}
