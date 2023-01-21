namespace IvanRealEstate.Entities.Exceptions
{
    public class OwnerNotFoundException : NotFoundException
    {
        public OwnerNotFoundException(Guid ownerId)
          : base($"The owner with id:{ownerId} doesn't exist in the database.")
        {

        }
    }
}
