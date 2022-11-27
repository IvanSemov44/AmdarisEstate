using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObject.Country
{
    public record CountryDto
    {
        public Guid CountryId { get; init; }

        public string? CountryName { get; init; }
    }
}
