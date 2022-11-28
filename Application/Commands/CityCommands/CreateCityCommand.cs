namespace Application.Commands.CityCommands
{
    using MediatR;
    using Shared.DataTransferObject.City;

    public sealed record CreateCityCommand(CityForCreationDto CityForCreationDto):IRequest<CityDto>;
}
