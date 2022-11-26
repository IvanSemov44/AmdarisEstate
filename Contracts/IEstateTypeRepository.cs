﻿using Entities.Models;

namespace Contracts
{
    public interface IEstateTypeRepository
    {
        Task<IEnumerable<EstateType>> GetEstateTypesAsync(bool trackChanges);
        Task<EstateType> GetEstateTypeAsync(Guid estateTypeId, bool trackChanges);
        Task<EstateType> GetEstateTypeByNameAsync(string estateTypeName, bool trackChanges);
        void CreateEstateType(EstateType estateType);
        void DeleteEstateType(EstateType estateType);
    }
}