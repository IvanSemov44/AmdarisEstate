namespace IvanRealEstate.Shared.DataTransferObject.Estate
{
    public record EstateDto
    {
        public Guid EstateId { get; init; }
        public string? Neighborhood { get; init; }
        public string? Address { get; init; }
        public string? Description { get; init; }
        public int YearOfCreation { get; init; }
        public double Price { get; init; }
        public int Floоr { get; init; }
        public int Rooms { get; init; }
        public string? Extras { get; init; }
        public bool Sell { get; init; }
        public DateTime? Created { get; init; }
        public DateTime? Changed { get; init; }
        public IEnumerable<ImageDto>? Images { get; init; }
    }
}
