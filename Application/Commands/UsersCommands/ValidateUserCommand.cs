namespace IvanRealEstate.Application.Commands.UsersCommands
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Users;

    public sealed record ValidateUserCommand(UserForAuthenticationDto UserForAuthentication) : IRequest<bool>;
}
