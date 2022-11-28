namespace IvanRealEstate.Application.Commands.CompanyCommands
{
    using MediatR;
    using Shared.DataTransferObject;

    public sealed record UpdateCompanyCommand(Guid Id, CompanyForUpdateDto CompanyForUpdate, bool TrackChanges) : IRequest;
}
