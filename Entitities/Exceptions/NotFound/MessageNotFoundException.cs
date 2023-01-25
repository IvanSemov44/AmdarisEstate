namespace IvanRealEstate.Entities.Exceptions.NotFound
{
    public class MessageNotFoundException : NotFoundException
    {
        public MessageNotFoundException(Guid messageId)
            : base($"The user with id:{messageId} doesn't exist in the database.")
        {

        }
    }
}