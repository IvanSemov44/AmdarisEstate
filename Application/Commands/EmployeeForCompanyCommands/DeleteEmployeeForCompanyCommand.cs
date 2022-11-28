using MediatR;

namespace Application.Commands.EmployeeForCompanyCommands
{
    public sealed record DeleteEmployeeForCompanyCommand(Guid CompanyId, Guid EmployeeId, bool TrackChanges) : IRequest;
}
