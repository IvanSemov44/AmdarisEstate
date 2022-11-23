using MediatR;
using Shared.DataTransferObject;

namespace Application.Queries.CompanyQueries
{
    public sealed record GetCompanyQuery(Guid Id, bool TrackChanges) : IRequest<CompanyDto>;
}
