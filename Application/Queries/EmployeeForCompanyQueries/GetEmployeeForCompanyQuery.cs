namespace Application.Queries.EmployeeForCompanyQueries
{
    using MediatR;
    using Shared.DataTransferObject;

    public sealed record GetEmployeeForCompanyQuery(Guid CompanyId, Guid EmployeeId, bool TrackChanges) : IRequest<EmployeeDto>;
}
