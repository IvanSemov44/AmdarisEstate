namespace Application.Commands.CountryCommands
{
    using MediatR;
    using Shared.DataTransferObject.Country;

    public sealed record CreateCountryCommand(CountryForCreationDto CountryForCreationDto) : IRequest<CountryDto>;
}
