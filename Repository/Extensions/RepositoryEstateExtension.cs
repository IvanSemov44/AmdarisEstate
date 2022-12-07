namespace IvanRealEstate.Repository.Extensions
{
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Shared.RequestFeatures;

    public static class RepositoryEstateExtension
    {
        public static IQueryable<Estate> FilterEstate(
            this IQueryable<Estate> estates,EstateParameters estateParameters) =>
             estates.Where(e =>
             e.YearOfCreation >= estateParameters.MinYear &&
             e.YearOfCreation <= estateParameters.MaxYear &&
             e.CityId == estateParameters.City);

        public static IQueryable<Estate> Search(this IQueryable<Estate> estates, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return estates;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return estates.Where(e => e.Neighborhood.ToLower().Contains(lowerCaseTerm));
        }
    }
}
