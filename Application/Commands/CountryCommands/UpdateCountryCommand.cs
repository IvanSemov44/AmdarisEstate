using MediatR;
using Shared.DataTransferObject.Country;

namespace Application.Commands.CountryCommands
{
    public record UpdateCountryCommand
        (Guid CountryId, CountryForUpdateDto CountryForUpdateDto, bool TrackChanges) : IRequest;
}
