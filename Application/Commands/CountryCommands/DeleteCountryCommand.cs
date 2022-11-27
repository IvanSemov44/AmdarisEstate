using MediatR;

namespace Application.Commands.CountryCommands
{
    public record DeleteCountryCommand(Guid CountryId,bool TrackChanges):IRequest;
}
