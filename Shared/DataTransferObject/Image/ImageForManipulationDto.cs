namespace IvanRealEstate.Shared.DataTransferObject.Image
{
    public abstract record ImageForManipulationDto
    {
        public string? ImageUrl { get; init; }
    }
}
