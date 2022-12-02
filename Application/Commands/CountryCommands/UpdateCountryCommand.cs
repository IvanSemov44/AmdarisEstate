namespace IvanRealEstate.Application.Commands.CountryCommands
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Country;

    public sealed record UpdateCountryCommand
        (Guid CountryId, CountryForUpdateDto CountryForUpdateDto, bool TrackChanges) : IRequest;
}
