namespace IvanRealEstate.Application.Commands.EstateCommands
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Estate;

    public sealed record CreateEstateCommand(EstateForCreationDto EstateForCreationDto):IRequest<EstateDto>;
}
