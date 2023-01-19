namespace IvanRealEstate.Entities.Exceptions
{
    public sealed class MaxFloorRangeBadRequestException : BadRequestException
    {
        public MaxFloorRangeBadRequestException()
           : base("Max floor can't be less than min year.")
        {
        }
    }
}
