namespace IvanRealEstate.Application.Handlers.MessageHandlers
{
    using MediatR;
    using AutoMapper;

    using Microsoft.AspNetCore.Identity;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Application.Queries.MessageQuery;
    using IvanRealEstate.Shared.DataTransferObject.Message;

    public sealed class GetAllMessageHandler : IRequestHandler<GetAllMessagesQuery, IEnumerable<MessageDto>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IRepositoryManager _repositoryManager;


        public GetAllMessageHandler(IRepositoryManager repositoryManager, IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<MessageDto>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
        {
            await _userManager.FindByIdAsync(request.OwnerId.ToString());

            var messages = await _repositoryManager.Message.GetMessagesAsync(request.OwnerId, request.TrackChanges);

            return _mapper.Map<IEnumerable<MessageDto>>(messages);
        }
    }
}
