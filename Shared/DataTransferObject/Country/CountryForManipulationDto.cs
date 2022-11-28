namespace Shared.DataTransferObject.Country
{
    using System.ComponentModel.DataAnnotations;

    public abstract record CountryForManipulationDto
    {
        [Required(ErrorMessage = "Country name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the CountryName is 30 characters.")]
        public string? CountryName { get; init; }
    }
}
