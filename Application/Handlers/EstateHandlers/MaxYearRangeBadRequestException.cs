namespace IvanRealEstate.Application.Handlers.EstateHandlers
{
    using IvanRealEstate.Entities.Exceptions;

    public sealed class MaxYearRangeBadRequestException : BadRequestException
    {
        public MaxYearRangeBadRequestException()
            : base("Max year can't be less than min year.")
        {
        }
    }
}
