namespace IvanRealEstate.Repository
{
    using Microsoft.EntityFrameworkCore;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;

    public class CompanyImageRepository : RepositoryBase<Image>, ICompanyImageRepository
    {
        public CompanyImageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCompanyImage(Guid companyId, Image image)
        {
            image.CompanyId = companyId;
            Create(image);
        }

        public void DeleteCompanyImage(Image image) => Delete(image);

        public async Task<Image?> GetCompanyImageAsync(Guid companyId, Guid imageId, bool trackChanges) =>
             await FindByCondition(i => i.CompanyId.Equals(companyId) && i.CompanyId.Equals(imageId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Image>> GetCompanyImagesAsync(Guid companyId, bool trackChanges) =>
        await FindByCondition(i => i.CompanyId.Equals(companyId), trackChanges).ToListAsync();
    }
}
