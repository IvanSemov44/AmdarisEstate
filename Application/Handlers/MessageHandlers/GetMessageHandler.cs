namespace IvanRealEstate.Application.Handlers.MessageHandlers
{
    using MediatR;
    using AutoMapper;

    using Microsoft.AspNetCore.Identity;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Application.Queries.MessageQuery;
    using IvanRealEstate.Shared.DataTransferObject.Message;

    public sealed class GetMessageHandler : IRequestHandler<GetMessageQuery, MessageDto>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IRepositoryManager _repositoryManager;

        public GetMessageHandler(IMapper mapper, IRepositoryManager repositoryManager,UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _repositoryManager = repositoryManager;
        }

        public async Task<MessageDto> Handle(GetMessageQuery request, CancellationToken cancellationToken)
        {
            await _userManager.FindByIdAsync(request.OwnerId.ToString());
            
            var message = await CheckerForMessage.CheckIfMessageExistAndReturnIt(
                _repositoryManager, request.OwnerId, request.MessageId, request.TrackChanges);

            var messageForReturn = _mapper.Map<MessageDto>(message);

            return messageForReturn;
        }
    }
}
