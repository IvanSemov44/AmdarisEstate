namespace IvanRealEstate.Application.Queries.EmployeeForCompanyQueries
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject;

    public sealed record GetEmployeesForCompanyQuery(Guid CompanyId, bool TrackChanges) : IRequest<IEnumerable<EmployeeDto>>;
}
