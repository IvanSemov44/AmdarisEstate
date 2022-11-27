using MediatR;

namespace Application.Commands.CityCommands
{
    public record DeleteCityCommand(Guid Id,bool TrackChanges) : IRequest;
}
