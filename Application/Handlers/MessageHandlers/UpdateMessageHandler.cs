namespace IvanRealEstate.Application.Handlers.MessageHandlers
{
    using MediatR;
    using AutoMapper;

    using Microsoft.AspNetCore.Identity;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Application.Commands.MessageCommands;

    public sealed class UpdateMessageHandler : IRequestHandler<UpdateMessageCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IRepositoryManager _repositoryManager;

        public UpdateMessageHandler(IRepositoryManager repositoryManager, IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            await _userManager.FindByIdAsync(request.OwnerId.ToString());

            var message = await CheckerForMessage.CheckIfMessageExistAndReturnIt(
                _repositoryManager, request.OwnerId, request.MessageId, request.TrackChages);

            _mapper.Map(request.MessageForUpdate, message);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
