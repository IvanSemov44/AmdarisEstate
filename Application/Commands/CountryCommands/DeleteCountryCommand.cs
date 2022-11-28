namespace IvanRealEstate.Application.Commands.CountryCommands
{
    using MediatR;

    public sealed record DeleteCountryCommand(Guid CountryId,bool TrackChanges):IRequest;
}
