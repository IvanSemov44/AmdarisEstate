namespace IvanRealEstate.Application.Handlers.UsersHandlers
{
    using MediatR;
    using AutoMapper;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;

    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Application.Commands.UsersCommands;

    public sealed class RegisterUsersHandler : IRequestHandler<RegisterUsersCommand, IdentityResult>
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;

        public RegisterUsersHandler(IMapper mapper, IConfiguration config, UserManager<User> userManager)
        {
            _mapper = mapper;
            _config = config;
            _userManager = userManager;
        }

        public async Task<IdentityResult> Handle(RegisterUsersCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.UserForRegistration);

            var result = await _userManager.CreateAsync(user, request.UserForRegistration.Password);

            if (result.Succeeded)
                await _userManager.AddToRolesAsync(user, request.UserForRegistration.Roles);

            return result;
        }
    }
}
