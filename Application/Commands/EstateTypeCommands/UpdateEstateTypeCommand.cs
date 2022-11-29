namespace IvanRealEstate.Application.Commands.EstateTypeCommands
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.EstateType;

    public sealed record UpdateEstateTypeCommand
        (Guid EstateTypeId, EstateTypeForUpdateDto EstateTypeForUpdateDto, bool TrackChanges) : IRequest;
}
