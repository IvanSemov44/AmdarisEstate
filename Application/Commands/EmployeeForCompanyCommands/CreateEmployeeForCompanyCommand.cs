namespace IvanRealEstate.Application.Commands.EmployeeForCompanyCommands
{
    using MediatR;
    using Shared.DataTransferObject;

    public sealed record CreateEmployeeForCompanyCommand(Guid CompanyId, EmployeeForCreationDto Employee, bool TrackChanges)
        : IRequest<EmployeeDto>;
}
