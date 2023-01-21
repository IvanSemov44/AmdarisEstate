namespace IvanRealEstate.Shared.DataTransferObject.Message
{
    public record MessageDto
    {
        public Guid Id { get; init; }

        public string? Name { get; init; }

        public string? Email { get; init; }

        public string? Text { get; init; }

        public bool? IsRead { get; init; }

        public DateTime? Created { get; init; }
    }
}
