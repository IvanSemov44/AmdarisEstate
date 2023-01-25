namespace IvanRealEstate.Application.Handlers.UsersHandlers
{
    using MediatR;
    using AutoMapper;

    using Microsoft.AspNetCore.Identity;

    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Application.Queries.UsersQuery;
    using IvanRealEstate.Shared.DataTransferObject.Users;

    public sealed class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public GetUserByIdHandler(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _userManager.FindByIdAsync(request.userId.ToString());

            var resultForReturn = _mapper.Map<UserDto>(result);

            return resultForReturn;
        }
    }
}
