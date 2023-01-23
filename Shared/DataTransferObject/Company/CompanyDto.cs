namespace IvanRealEstate.Shared.DataTransferObject.Company
{
    using IvanRealEstate.Shared.DataTransferObject.Image;
    using System.ComponentModel.DataAnnotations;

    public record CompanyDto
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? Address { get; init; }
        public string? Description { get; set; }
        public Guid? CompanyCityId { get; init; }
        public Guid? CompanyCountryId { get; set; }
        public ICollection<ImageDto>? Images { get; set; }
    };
}
