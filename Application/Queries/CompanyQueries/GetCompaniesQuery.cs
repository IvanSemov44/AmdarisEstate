using MediatR;
using Shared.DataTransferObject;

namespace Application.Queries.CompanyQueries
{
    public sealed record GetCompaniesQuery(bool TrackChanges) : IRequest<IEnumerable<CompanyDto>>;
}
