namespace IvanRealEstate.Entities.Exceptions.NotFound
{
    using IvanRealEstate.Entities.Models;

    public class CurrencyNotFoundException : NotFoundException
    {
        public CurrencyNotFoundException(Guid currencyId)
            : base($"Currency with id:{currencyId} doesn't exist in the database")
        {

        }
    }
}
