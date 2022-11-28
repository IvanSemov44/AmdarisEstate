using MediatR;
using Shared.DataTransferObject;

namespace Application.Queries.EmployeeForCompanyQueries
{
    public sealed record GetEmployeeForCompanyQuery(Guid CompanyId, Guid EmployeeId, bool TrackChanges) : IRequest<EmployeeDto>;
}
