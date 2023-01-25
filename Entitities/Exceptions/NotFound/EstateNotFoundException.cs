namespace IvanRealEstate.Entities.Exceptions.NotFound
{
    public class EstateNotFoundException : NotFoundException
    {
        public EstateNotFoundException(Guid estateId)
            : base($"The estate with id:{estateId} doesn't exist in the database.")
        {
        }
    }
}
