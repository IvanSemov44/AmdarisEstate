namespace IvanRealEstate.Application.Commands.CityCommands
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.City;

    public sealed record CreateCityCommand(CityForCreationDto CityForCreationDto):IRequest<CityDto>;
}
