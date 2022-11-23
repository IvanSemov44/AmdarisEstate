using MediatR;

namespace Application.Commands.EmployeeForCompanyCommands
{
    public record DeleteEmployeeForCompanyCommand(Guid CompanyId, Guid EmployeeId, bool TrackChanges) : IRequest;
}
