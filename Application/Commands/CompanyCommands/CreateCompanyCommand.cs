using MediatR;
using Shared.DataTransferObject;

namespace Application.Commands.CompanyCommands
{
    public sealed record CreateCompanyCommand(CompanyForCreationDto CompanyForCreation) : IRequest<CompanyDto>;
}
