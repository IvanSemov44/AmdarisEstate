namespace Application.Commands.EstateCommands
{
    using MediatR;
    using Shared.DataTransferObject.Estate;

    public sealed record CreateEstateCommand(EstateForCreationDto EstateForCreationDto):IRequest<EstateDto>;
}
