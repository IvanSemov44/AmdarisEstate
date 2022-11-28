namespace IvanRealEstate.Shared.DataTransferObject.Currency
{
    using System.ComponentModel.DataAnnotations;

    public abstract record CurrencyForManipulationDto
    {
        [Required(ErrorMessage = "Curency name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Curency is 30 characters.")]
        public string? CurrencyName { get; init; }
    }
}
