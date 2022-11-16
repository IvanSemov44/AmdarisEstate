using MediatR;
using Shared.DataTransferObject;

namespace Application.Queries
{
    public sealed record GetCompaniesQuery(bool TrackChanges) : IRequest<IEnumerable<CompanyDto>>;
}
