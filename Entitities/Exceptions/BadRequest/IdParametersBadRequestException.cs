﻿namespace IvanRealEstate.Entities.Exceptions.BadRequest
{
    public sealed class IdParametersBadRequestException : BadRequestException
    {
        public IdParametersBadRequestException()
            : base("Parameters ids is null")
        {

        }
    }
}
