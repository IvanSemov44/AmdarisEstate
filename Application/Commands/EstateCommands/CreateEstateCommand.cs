using MediatR;
using Shared.DataTransferObject.Estate;

namespace Application.Commands.EstateCommands
{
    public record CreateEstateCommand(EstateForCreationDto EstateForCreationDto):IRequest<EstateDto>;
}
