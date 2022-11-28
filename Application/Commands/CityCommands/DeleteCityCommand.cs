using MediatR;

namespace Application.Commands.CityCommands
{
    public sealed record DeleteCityCommand(Guid Id,bool TrackChanges) : IRequest;
}
