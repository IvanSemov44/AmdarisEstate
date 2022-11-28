using MediatR;
using Shared.DataTransferObject.City;

namespace Application.Commands.CityCommands
{
    public sealed record CreateCityCommand(CityForCreationDto CityForCreationDto):IRequest<CityDto>;
}
