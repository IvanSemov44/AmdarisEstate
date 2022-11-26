using MediatR;
using Shared.DataTransferObject.City;

namespace Application.Commands.CityCommands
{
    public record CreateCityCommand(CityForCreationDto CityForCreationDto):IRequest<CityDto>;
}
