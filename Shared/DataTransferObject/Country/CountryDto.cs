namespace Shared.DataTransferObject.Country
{
    using System.ComponentModel.DataAnnotations;

    public record CountryDto
    {
        public Guid CountryId { get; init; }

        public string? CountryName { get; init; }
    }
}
