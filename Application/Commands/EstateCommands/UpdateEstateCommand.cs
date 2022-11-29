namespace IvanRealEstate.Application.Commands.EstateCommands
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Estate;

    public sealed record UpdateEstateCommand
        (Guid EstateId,EstateForUpdateDto EstateForUpdateDto, bool TrackChanges):IRequest;
}
