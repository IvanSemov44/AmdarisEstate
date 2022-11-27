using MediatR;
using Shared.DataTransferObject.Country;

namespace Application.Queries.CountryQueries
{
    public record GetCountryQuery(Guid CountryId,bool TrackChanges):IRequest<CountryDto>;
}
