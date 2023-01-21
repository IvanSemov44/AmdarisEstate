namespace IvanRealEstate.Entities.Exceptions
{
    public class MessageNotFoundException: NotFoundException
    {
        public MessageNotFoundException(Guid messageId)
            : base($"The message with id:{messageId} doesn't exist in the database.")
        {

        }
    }
}