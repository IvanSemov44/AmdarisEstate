namespace IvanRealEstate.Application.Commands.CompanyCommands
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Company;

    public sealed record CreateCompanyCommand(CompanyForCreationDto CompanyForCreation) : IRequest<CompanyDto>;
}
