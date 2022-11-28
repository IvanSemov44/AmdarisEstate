namespace IvanRealEstate.Application.Commands.CompanyCommands
{
    using MediatR;
    using Shared.DataTransferObject;

    public sealed record CreateCompanyCommand(CompanyForCreationDto CompanyForCreation) : IRequest<CompanyDto>;
}
