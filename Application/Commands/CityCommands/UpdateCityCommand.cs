namespace Application.Commands.CityCommands
{
    using MediatR;
    using Shared.DataTransferObject.City;

    public sealed record UpdateCityCommand
        (Guid CityId, CityForUpdateDto CityForUpdateDto, bool TrackChanges) : IRequest;
}
