using MediatR;
using Shared.DataTransferObject;

namespace Application.Queries.EmployeeForCompanyQueries
{
    public sealed record GetEmployeesForCompanyQuery(Guid CompanyId, bool TrackChanges) : IRequest<IEnumerable<EmployeeDto>>;
}
