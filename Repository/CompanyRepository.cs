﻿namespace IvanRealEstate.Repository
{
    using Microsoft.EntityFrameworkCore;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using System.Linq.Dynamic.Core;

    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public async Task<IEnumerable<Company?>> GetAllCompaniesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();

        public async Task<IEnumerable<Company?>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
           await FindByCondition(x => ids.Contains(x.Id), trackChanges).Include(x=>x.Employees).ToListAsync();

        public async  Task<Company?> GetCompanyAsync(Guid companyId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(companyId), trackChanges).Include(x => x.Employees).SingleOrDefaultAsync();

        public void CreateCompany(Company company) => Create(company);

        public void DeleteCompany(Company company) => Delete(company);
    }
}
