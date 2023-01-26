namespace IvanRealEstate.Shared.DataTransferObject.CompanyImage
{
    public record CompanyImageDto
    {
        public Guid CompanyImageId { get; init; }
        public string? ImageUrl { get; init; }
        public bool? DefaultImg { get; set; }
    }
}
