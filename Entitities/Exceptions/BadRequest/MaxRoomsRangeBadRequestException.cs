﻿namespace IvanRealEstate.Entities.Exceptions.BadRequest
{
    public sealed class MaxRoomsRangeBadRequestException : BadRequestException
    {
        public MaxRoomsRangeBadRequestException()
            : base("Max rooms can't be less than min year.")
        {
        }
    }
}
