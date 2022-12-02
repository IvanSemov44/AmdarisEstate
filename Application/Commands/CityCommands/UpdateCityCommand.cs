namespace IvanRealEstate.Application.Commands.CityCommands
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.City;

    public sealed record UpdateCityCommand
        (Guid CityId, CityForUpdateDto CityForUpdateDto, bool TrackChanges) : IRequest;
}
