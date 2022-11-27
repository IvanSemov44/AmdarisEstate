using MediatR;
using Shared.DataTransferObject.Country;

namespace Application.Queries.CountryQueries
{
    public record GetCountriesQuiry(bool TrackChanges) : IRequest<IEnumerable<CountryDto>>;
}
