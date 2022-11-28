namespace IvanRealEstate.Shared.DataTransferObject.Currency
{
    public record CurrencyDto
    {
        public Guid CurrencyId { get; set; }
        public string? CurrencyName { get; set; }
    }
}
