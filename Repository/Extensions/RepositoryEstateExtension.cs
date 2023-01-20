namespace IvanRealEstate.Repository.Extensions
{
    using System.Linq.Dynamic.Core;

    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Shared.RequestFeatures;

    public static class RepositoryEstateExtension
    {
        public static IQueryable<Estate> FilterEstate(
            this IQueryable<Estate> estates, EstateParameters estateParameters)
        {
            var returnEstates = estates.Where(e =>
             e.YearOfCreation >= estateParameters.MinYear &&
             e.YearOfCreation <= estateParameters.MaxYear);

            returnEstates = returnEstates.Where(e =>
             e.Price >= estateParameters.MinPrice &&
             e.Price <= estateParameters.MaxPrice);

            returnEstates = returnEstates.Where(e =>
             e.Rooms >= estateParameters.MinRooms &&
             e.Rooms <= estateParameters.MaxRooms);

            returnEstates = returnEstates.Where(e =>
             e.Floor >= estateParameters.MinFloor &&
             e.Floor <= estateParameters.MaxFloor);

            returnEstates = returnEstates.Where(e =>
             e.EstateArea >= estateParameters.MinArea &&
             e.EstateArea <= estateParameters.MaxArea);

            if (estateParameters.Sell is not null)
                returnEstates = returnEstates.Where(e =>
                e.Sell == estateParameters.Sell);

            if (estateParameters.City is not null)
                returnEstates = returnEstates.Where(e =>
                   e.CityId == estateParameters.City);

            if (estateParameters.Country is not null)
                returnEstates = returnEstates.Where(e =>
                e.CountryId == estateParameters.Country);

            if (estateParameters.Currency is not null)
                returnEstates = returnEstates.Where(e =>
                e.CurencyId == estateParameters.Currency);

            if (estateParameters.EstateType is not null)
                returnEstates = returnEstates.Where(e =>
                e.EstateTypeId == estateParameters.EstateType);

            return returnEstates;
        }

        public static IQueryable<Estate> Search(this IQueryable<Estate> estates, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return estates;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return estates.Where(e =>
            e.Neighborhood.ToLower().Contains(lowerCaseTerm) ||
            e.Extras.ToLower().Contains(lowerCaseTerm) ||
            e.Description.ToLower().Contains(lowerCaseTerm) ||
            e.Address.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Estate> Sort(this IQueryable<Estate> estate, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return estate.OrderBy(e => e.Changed);

            var orderQuery = OrderQueryBulder.CreateOrderQuery<Estate>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return estate.OrderBy(e => e.Changed);

            return estate.OrderBy(orderQuery);
        }
    }
}
