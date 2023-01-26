namespace IvanRealEstate.Application.Commands.ImageCommads
{
    using MediatR;

    public sealed record DeleteCountryImageCommand(Guid EstateId, Guid ImageId,bool TrackChanges) :IRequest;
}
