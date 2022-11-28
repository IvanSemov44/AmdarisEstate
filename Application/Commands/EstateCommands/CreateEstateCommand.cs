using MediatR;
using Shared.DataTransferObject.Estate;

namespace Application.Commands.EstateCommands
{
    public sealed record CreateEstateCommand(EstateForCreationDto EstateForCreationDto):IRequest<EstateDto>;
}
