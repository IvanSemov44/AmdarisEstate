namespace IvanRealEstate.Application.Commands.UsersCommands
{
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using IvanRealEstate.Shared.DataTransferObject.Users;

    public sealed record RegisterUsersCommand(UserForRegistrationDto UserForRegistration)
        : IRequest<IdentityResult>;
}
