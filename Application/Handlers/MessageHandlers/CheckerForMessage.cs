using IvanRealEstate.Contracts;
using IvanRealEstate.Entities.Exceptions;
using IvanRealEstate.Entities.Models;

namespace IvanRealEstate.Application.Handlers.MessageHandlers
{
    public class CheckerForMessage
    {
        public async static Task<Message> CheckIfMessageExistAndReturnIt(IRepositoryManager repositoryManager, Guid ownerId, Guid messageId, bool trackChanges)
        {
            var message = await repositoryManager.Message.GetMessageByIdAsync(ownerId, messageId, trackChanges);
            if (message is null)
                throw new MessageNotFoundException(messageId);

            return message;
        }
    }
}
