namespace IvanRealEstate.Shared.DataTransferObject.OwnerImage
{
    public record OwnerImageDto
    {
        public Guid OwnerImageId { get; init; }
        public string? ImageUrl { get; init; }
        public bool? DefaultImg { get; set; }
    }
}
