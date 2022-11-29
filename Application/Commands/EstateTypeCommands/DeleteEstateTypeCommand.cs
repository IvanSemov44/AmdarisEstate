namespace IvanRealEstate.Application.Commands.EstateTypeCommands
{
    using MediatR;

    public sealed record DeleteEstateTypeCommand(Guid EstateTypeId, bool TrackChanges):IRequest;    
}
