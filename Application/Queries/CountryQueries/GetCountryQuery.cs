﻿using MediatR;
using Shared.DataTransferObject.Country;

namespace Application.Queries.CountryQueries
{
    public sealed record GetCountryQuery(Guid CountryId,bool TrackChanges):IRequest<CountryDto>;
}
