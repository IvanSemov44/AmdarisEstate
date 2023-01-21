namespace IvanRealEstate.Repository
{
    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using Microsoft.EntityFrameworkCore;

    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateMessage(Guid ownerId, Message message)
        {
            message.OwnerId = ownerId;
            Create(message);
        }
        public void DeleteMessage(Message message) => Delete(message);

        public async Task<Message?> GetMessageByIdAsync(Guid ownerId, Guid messageId, bool trackChanges) =>
            await FindByCondition(m => m.OwnerId.Equals(ownerId) && m.Id.Equals(messageId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Message?>> GetMessagesAsync(Guid ownerId, bool trackChanges) =>
            await FindByCondition(m => m.OwnerId.Equals(ownerId), trackChanges)
            .OrderBy(c => c.Created)
            .ToListAsync();
    }
}
