namespace IvanRealEstate.Application.Commands.ImageCommads
{
    using MediatR;

    public sealed record DeleteImageCommand(Guid EstateId, Guid ImageId,bool TrackChanges) :IRequest;
}
