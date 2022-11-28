﻿using MediatR;
using Shared.DataTransferObject.City;
using Shared.DataTransferObject.Country;

namespace Application.Commands.CountryCommands
{
    public sealed record CreateCountryCommand(CountryForCreationDto CountryForCreationDto) : IRequest<CountryDto>;
}
