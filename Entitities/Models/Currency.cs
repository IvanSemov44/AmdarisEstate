namespace IvanRealEstate.Entities.Models
{
    public class Currency
    {
        public Guid CurrencyId { get; set; }

        public string? CurrencyName { get; set; }

        public ICollection<Estate>? Estate { get; set; }
    }
}
