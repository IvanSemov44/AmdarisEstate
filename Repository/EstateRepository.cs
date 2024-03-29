﻿namespace IvanRealEstate.Repository
{
    using Microsoft.EntityFrameworkCore;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Shared.RequestFeatures;
    using IvanRealEstate.Repository.Extensions;

    public class EstateRepository : RepositoryBase<Estate>, IEstateRepository
    {
        public EstateRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Estate>> GetAllEstatesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .Include(b => b.Images)
            .OrderBy(e => e.YearOfCreation)
            .ToListAsync();

        public async Task<PagedList<Estate>> GetEstatesForPageAsync
            (EstateParameters estateParameters, bool trackChanges)
        {
            var estates = await FindAll(trackChanges)
                .FilterEstate(estateParameters)
                .Search(estateParameters.SearchTerm)
                .Include(b => b.Images)
                .Sort(estateParameters.OrderBy)
                .Skip((estateParameters.PageNumber - 1) * estateParameters.PageSize)
                .Take(estateParameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChanges)
                .FilterEstate(estateParameters)
                .Search(estateParameters.SearchTerm).CountAsync();

            return new PagedList<Estate>(estates, count, estateParameters.PageNumber, estateParameters.PageSize);
        }

        public async Task<Estate?> GetEstateAsync(Guid estateId, bool trackChanges) =>
            await FindByCondition(e => e.EstateId.Equals(estateId), trackChanges)
            .Include(b => b.Images)
            .SingleOrDefaultAsync();

        public void CreateEstate(Estate estate) => Create(estate);

        public void DeleteEstate(Estate estate) => Delete(estate);

    }
}
