namespace IvanRealEstate.Entities.Exceptions.BadRequest
{
    public sealed class MaxPriceRangeBadRequestException : BadRequestException
    {
        public MaxPriceRangeBadRequestException()
            : base("Max price can't be less than min year.")
        {
        }
    }
}
