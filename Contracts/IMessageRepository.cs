namespace IvanRealEstate.Contracts
{
    using IvanRealEstate.Entities.Models;

    public interface IMessageRepository
    {
        Task<IEnumerable<Message?>> GetMessagesAsync(Guid ownerId,bool trackChanges);
        Task<Message?> GetMessageByIdAsync(Guid ownerId, Guid messageId, bool trackChanges);
        void CreateMessage(Guid ownerId,Message message);
        void DeleteMessage(Message message);
    }
}
