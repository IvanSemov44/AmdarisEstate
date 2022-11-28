namespace Application.Queries.EmployeeForCompanyQueries
{
    using MediatR;
    using Shared.DataTransferObject;

    public sealed record GetEmployeesForCompanyQuery(Guid CompanyId, bool TrackChanges) : IRequest<IEnumerable<EmployeeDto>>;
}
