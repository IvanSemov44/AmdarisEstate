
namespace Entities.Exceptions
{
    public class CountryNotFoundException : NotFoundException
    {
        public CountryNotFoundException(Guid id):base($"The country with id:{id} doesn't exist in the database.")
        {

        }
    }
}
