using MediatR;

namespace Application.Commands.CountryCommands
{
    public sealed record DeleteCountryCommand(Guid CountryId,bool TrackChanges):IRequest;
}
