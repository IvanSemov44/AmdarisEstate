namespace IvanRealEstate.Application.Handlers.MessageHandlers
{
    using MediatR;
    using AutoMapper;

    using Microsoft.AspNetCore.Identity;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Shared.DataTransferObject.Message;
    using IvanRealEstate.Application.Commands.MessageCommands;

    public sealed class CreateMessageHandler : IRequestHandler<CreateMessageCommand, MessageDto>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IRepositoryManager _repositoryManager;

        public CreateMessageHandler(IRepositoryManager repositoryManager, IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _repositoryManager = repositoryManager;
        }

        public async Task<MessageDto> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            await _userManager.FindByIdAsync(request.OwnerId.ToString());

            var message = _mapper.Map<Message>(request.MessageForCreation);

            message.Created = DateTime.UtcNow;

            _repositoryManager.Message.CreateMessage(request.OwnerId, message);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<MessageDto>(message);
        }
    }
}
