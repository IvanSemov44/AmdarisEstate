using MediatR;
using Shared.DataTransferObject;

namespace Application.Commands
{
    public sealed record CreateCompanyCommand(CompanyForCreationDto CompanyForCreation):IRequest<CompanyDto>;
}
