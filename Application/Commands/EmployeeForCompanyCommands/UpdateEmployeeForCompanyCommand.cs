namespace Application.Commands.EmployeeForCompanyCommands
{
    using MediatR;
    using Shared.DataTransferObject;

    public sealed record UpdateEmployeeForCompanyCommand(
        Guid CompanyId,
        Guid EmployeeId,
        EmployeeForUpdateDto Employee,
        bool CompanyTrackChanges,
        bool EmployeeTrackChanges)
        : IRequest;
}
