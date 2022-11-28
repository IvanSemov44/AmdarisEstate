﻿namespace IvanRealEstate.Entities.Exceptions
{
    public sealed class CityNotFoundException : NotFoundException
    {
        public CityNotFoundException(Guid id)
            : base($"The city with id:{id} doesn't exist in the database.")
        {

        }
    }
}
