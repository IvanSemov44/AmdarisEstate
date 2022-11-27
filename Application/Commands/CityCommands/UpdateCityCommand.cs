using MediatR;
using Shared.DataTransferObject.City;

namespace Application.Commands.CityCommands
{
    public sealed record UpdateCityCommand
        (Guid CityId, CityForUpdateDto CityForUpdateDto, bool TrackChanges) : IRequest;
}
