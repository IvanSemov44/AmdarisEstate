using MediatR;
using Shared.DataTransferObject;

namespace Application.Commands.EmployeeForCompanyCommands
{
    public sealed record UpdateEmployeeForCompanyCommand(
        Guid CompanyId,
        Guid EmployeeId,
        EmployeeForUpdateDto Employee,
        bool CompanyTrackChanges,
        bool EmployeeTrackChanges)
        : IRequest;
}
