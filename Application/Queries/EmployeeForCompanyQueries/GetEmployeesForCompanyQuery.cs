using MediatR;
using Shared.DataTransferObject;

namespace Application.Queries.EmployeeForCompanyQueries
{
    public record GetEmployeesForCompanyQuery(Guid CompanyId, bool TrackChanges) : IRequest<IEnumerable<EmployeeDto>>;
}
