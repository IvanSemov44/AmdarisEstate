namespace IvanRealEstate.Shared.DataTransferObject
{
    public record CompanyDto
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? Address { get; init; }
        public Guid? CompanyCityId { get; init; }

    };
}
