﻿namespace IvanRealEstate.Entities.Exceptions
{
    public class EstateTypeNotFoundException : NotFoundException
    {
        public EstateTypeNotFoundException(Guid estateTypeId) 
            : base($"EstateType with id:{estateTypeId} doesn't exist in the database")
        {
        }
    }
}
