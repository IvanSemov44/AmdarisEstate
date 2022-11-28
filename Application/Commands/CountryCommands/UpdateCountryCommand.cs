namespace IvanRealEstate.Application.Commands.CountryCommands
{
    using MediatR;
    using Shared.DataTransferObject.Country;

    public sealed record UpdateCountryCommand
        (Guid CountryId, CountryForUpdateDto CountryForUpdateDto, bool TrackChanges) : IRequest;
}
