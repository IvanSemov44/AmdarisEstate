namespace Application.Commands.CityCommands
{
    using MediatR;

    public sealed record DeleteCityCommand(Guid Id,bool TrackChanges) : IRequest;
}
