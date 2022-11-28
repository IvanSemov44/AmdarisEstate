namespace IvanRealEstate.Shared.DataTransferObject.Currency
{
    public record CurrencyDto
    {
        public Guid CurrencyId { get; init; }
        public string? CurrencyName { get; init; }
    }
}
