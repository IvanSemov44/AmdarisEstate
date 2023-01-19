namespace IvanRealEstate.Entities.Exceptions
{
    public sealed class MaxAreaRangeBadRequestException : BadRequestException
    {
        public MaxAreaRangeBadRequestException()
           : base("Max area can't be less than min year.")
        {
        }
    }
}
