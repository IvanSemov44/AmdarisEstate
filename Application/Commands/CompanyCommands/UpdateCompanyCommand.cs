namespace IvanRealEstate.Application.Commands.CompanyCommands
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Company;

    public sealed record UpdateCompanyCommand(Guid Id, CompanyForUpdateDto CompanyForUpdate, bool TrackChanges) : IRequest;
}
