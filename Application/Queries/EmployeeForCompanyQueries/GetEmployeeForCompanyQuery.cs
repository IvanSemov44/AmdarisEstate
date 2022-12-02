namespace IvanRealEstate.Application.Queries.EmployeeForCompanyQueries
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject;

    public sealed record GetEmployeeForCompanyQuery(Guid CompanyId, Guid EmployeeId, bool TrackChanges) : IRequest<EmployeeDto>;
}
