
namespace Application.Queries.CountryQueries
{
    using MediatR;
    using Shared.DataTransferObject.Country;

    public sealed record GetCountryQuery(Guid CountryId,bool TrackChanges):IRequest<CountryDto>;
}
