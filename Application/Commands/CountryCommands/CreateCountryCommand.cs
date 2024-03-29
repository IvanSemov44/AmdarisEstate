﻿namespace IvanRealEstate.Application.Commands.CountryCommands
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Country;

    public sealed record CreateCountryCommand(CountryForCreationDto CountryForCreationDto) : IRequest<CountryDto>;
}
