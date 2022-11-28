namespace IvanRealEstate.Shared.DataTransferObject.City
{
    public record CityDto
    {
        public Guid CityId { get; init; }
        public string? CityName { get; init; }
    }
}
