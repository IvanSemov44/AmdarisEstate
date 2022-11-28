namespace IvanRealEstate.Application.Commands.EstateTypeCommands
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.EstateType;

    public sealed record CreateEstateTypeCommand(EstateTypeForCreationDto EstateTypeForCreationDto):IRequest<EstateTypeDto>;
}
