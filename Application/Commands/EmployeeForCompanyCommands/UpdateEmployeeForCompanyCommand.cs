using MediatR;
using Shared.DataTransferObject;

namespace Application.Commands.EmployeeForCompanyCommands
{
    public record UpdateEmployeeForCompanyCommand(
        Guid CompanyId,
        Guid EmployeeId,
        EmployeeForUpdateDto Employee,
        bool CompanyTrackChanges,
        bool EmployeeTrackChanges)
        : IRequest;
}
