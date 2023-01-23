namespace IvanRealEstate.Entities.Exceptions.BadRequest
{
    public sealed class MaxYearRangeBadRequestException : BadRequestException
    {
        public MaxYearRangeBadRequestException()
            : base("Max year can't be less than min year.")
        {
        }
    }
}
