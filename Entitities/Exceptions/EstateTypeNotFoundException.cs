
using IvanRealEstate.Entities.Models;

namespace IvanRealEstate.Entities.Exceptions
{
    public class EstateTypeNotFoundException : NotFoundException
    {
        public EstateTypeNotFoundException(Guid estateTypeId) 
            : base($"Employee with id:{estateTypeId} doesn't exist in the database")
        {
        }
    }
}
