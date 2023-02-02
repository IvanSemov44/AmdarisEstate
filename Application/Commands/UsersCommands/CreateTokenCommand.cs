
namespace IvanRealEstate.Application.Commands.UsersCommands
{
    using IvanRealEstate.Shared.DataTransferObject.Users;
    using MediatR;
    public sealed record CreateTokenCommand(UserForAuthenticationDto UserForAuthentication) : IRequest<string>;
}
