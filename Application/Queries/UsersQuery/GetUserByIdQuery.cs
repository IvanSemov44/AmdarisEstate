namespace IvanRealEstate.Application.Queries.UsersQuery
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Users;

    public sealed record GetUserByIdQuery(Guid userId):IRequest<UserDto>;
}
