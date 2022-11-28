using MediatR;
using Shared.DataTransferObject;

namespace Application.Commands.EmployeeForCompanyCommands
{
    public sealed record CreateEmployeeForCompanyCommand(Guid CompanyId, EmployeeForCreationDto Employee, bool TrackChanges)
        : IRequest<EmployeeDto>;
}
