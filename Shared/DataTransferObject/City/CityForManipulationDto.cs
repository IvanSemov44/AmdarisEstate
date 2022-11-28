namespace IvanRealEstate.Shared.DataTransferObject.City
{
    using System.ComponentModel.DataAnnotations;

    public abstract record CityForManipulationDto
    {
        [Required(ErrorMessage = "City name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string? CityName { get; init; }
    }
}
