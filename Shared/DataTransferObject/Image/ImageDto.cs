namespace IvanRealEstate.Shared.DataTransferObject.Image
{
    public record ImageDto
    {
        public Guid ImageId { get; init; }
        public string? ImageUrl { get; init; }
        public bool? DefaultImg { get; set; }

    }
}
