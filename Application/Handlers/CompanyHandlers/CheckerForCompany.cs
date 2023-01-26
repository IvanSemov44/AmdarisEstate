namespace IvanRealEstate.Application.Handlers.CompanyHandlers
{
    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Entities.Exceptions.NotFound;

    public class CheckerForCompany
    {
        public async static Task<Company> CheckIfCompanyExistAndReturnIt(IRepositoryManager repositoryManager, Guid companyId, bool trackChanges)
        {
            var company = await repositoryManager.Company.GetCompanyAsync(companyId, trackChanges);
            if (company is null)
                throw new CountryNotFoundException(companyId);

            return company;
        }
    }
}
