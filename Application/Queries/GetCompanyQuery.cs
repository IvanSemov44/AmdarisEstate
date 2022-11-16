using MediatR;
using Shared.DataTransferObject;

namespace Application.Queries
{
    public sealed record  GetCompanyQuery(Guid Id, bool TrackChanges): IRequest<CompanyDto>;
}
