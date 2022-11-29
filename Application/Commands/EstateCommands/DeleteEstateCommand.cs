namespace IvanRealEstate.Application.Commands.EstateCommands
{
    using MediatR;

    public sealed record DeleteEstateCommand(Guid EstateId,bool TrackChanges): IRequest;   
}
