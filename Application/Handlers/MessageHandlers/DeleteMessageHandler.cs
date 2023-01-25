namespace IvanRealEstate.Application.Handlers.MessageHandlers
{
    using MediatR;

    using Microsoft.AspNetCore.Identity;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Application.Commands.MessageCommands;

    public class DeleteMessageHandler : IRequestHandler<DeleteMessageCommand, Unit>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<User> _userManager;

        public DeleteMessageHandler(IRepositoryManager repositoryManager, UserManager<User> userManager)
        {
            _repositoryManager = repositoryManager;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            await _userManager.FindByIdAsync(request.OwnerId.ToString());

            var message =await CheckerForMessage.CheckIfMessageExistAndReturnIt(
                _repositoryManager, request.OwnerId, request.MessageId, request.TrackChanges);

            _repositoryManager.Message.DeleteMessage(message);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
