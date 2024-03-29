﻿namespace IvanRealEstate.Repository
{
    using Microsoft.EntityFrameworkCore;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;

    public class EstateTypeRepository : RepositoryBase<EstateType>, IEstateTypeRepository
    {
        public EstateTypeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEstateType(EstateType estateType) => Create(estateType);

        public void DeleteEstateType(EstateType estateType) => Delete(estateType);

        public async Task<EstateType?> GetEstateTypeAsync(Guid estateTypeId, bool trackChanges) =>
            await FindByCondition(e => e.EstateTypeId.Equals(estateTypeId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<EstateType>> GetEstateTypesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(e => e.TypeName)
            .ToListAsync();
    }
}
