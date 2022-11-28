namespace Application.Commands.EmployeeForCompanyCommands
{
    using MediatR;

    public sealed record DeleteEmployeeForCompanyCommand(Guid CompanyId, Guid EmployeeId, bool TrackChanges) : IRequest;
}
