namespace IvanRealEstate.Entities.Exceptions.BadRequest
{
    public abstract class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {

        }
    }
}
